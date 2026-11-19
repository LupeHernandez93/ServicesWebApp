using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;
using ServicesWebApp.Models;
using ServicesWebApp.Models.SupplierWebApp;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServicesWebApp.Controllers
{
    [Route("apiQMAX/[controller]/")]
    [ApiController]

    public class SupplierController : ControllerBase
    {
        #region Properties
        private readonly ILogger<SupplierController> _logger;
        private readonly IPortalRepositoryWrapper _repositoryportal;
        private readonly ISupplierAppRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Methods
        public SupplierController(ILogger<SupplierController> logger, IPortalRepositoryWrapper repositoryportal, ISupplierAppRepositoryWrapper repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mapper = mapper;
            _repositoryportal = repositoryportal;
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }


        /// <summary>
        /// Devuelve una lista de todos los proveedores con sus datos.
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                string tokenHeaders = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                var count = Convert.ToInt32((tokenHeaders.Length - 7));
                string token = tokenHeaders.Substring(7, count);

                TokenApplication listTokens = _repositoryportal.TokenApplication.FindByCondition(x => x.IdApplication == 5).SingleOrDefault();
                var TokenApplication = listTokens.Token;
                if (TokenApplication == token && listTokens.Status == true)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var JwToken = await Jwt.validarTokenAsync(identity);
                    if (!JwToken.success) return StatusCode(StatusCodes.Status404NotFound);
                    vtPerson Usuario = JwToken.result;
                    if (Usuario.Name == "Administrador" && Usuario.IdPerson == 1)
                    {
                        List<vtSupplier> Suppliers = await _repository.Supplier.GetAllSupplier();
                        if (Suppliers.Count() == 0)
                            return StatusCode(StatusCodes.Status204NoContent, new ProblemDetails { Title = "No se encontraron registros", Status = 204 });

                        List<DtSupplier> listSuppliers = _mapper.Map<List<DtSupplier>>(Suppliers);
                        return Ok(listSuppliers);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound);
                    }

                }
                else if (listTokens.Token != token)
                {
                    return StatusCode(StatusCodes.Status404NotFound);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }


        /// <summary>
        /// Devuelve el catálogo de tipos de proveedores y los documentos requeridos para cada uno de ellos.
        /// </summary>
        [HttpGet]
        [Route("CatTypeSupplier")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtTypeSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> CatTypeSupplier()
        {
            try
            {

                string tokenHeaders = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                var count = Convert.ToInt32((tokenHeaders.Length - 7));
                string token = tokenHeaders.Substring(7, count);

                //ClaimsIdentity identity = new ClaimsIdentity(HttpClien .AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role); = 
                //bool Authenticated = HttpContext.User.Identity.IsAuthenticated;
                TokenApplication listTokens = _repositoryportal.TokenApplication.FindByCondition(x => x.IdApplication == 5).SingleOrDefault();
                var TokenApplication = listTokens.Token;
                if (TokenApplication == token && listTokens.Status == true)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var JwToken = await Jwt.validarTokenAsync(identity);
                    if (!JwToken.success) return StatusCode(StatusCodes.Status404NotFound);
                    vtPerson Usuario = JwToken.result;
                    if (Usuario.Name == "Administrador" && Usuario.IdPerson == 1)
                    {
                        List<CatTypeSupplier> typeSuppliers = await _repository.TypeSupplier.FindAll().ToListAsync();
                        if (typeSuppliers.Count() == 0)
                            return StatusCode(StatusCodes.Status204NoContent, new ProblemDetails { Title = "No se encontraron registros", Status = 204 });

                        List<DtTypeSupplier> listtypeSuppliers = _mapper.Map<List<DtTypeSupplier>>(typeSuppliers);
                        List<CatDocument> listDocuments = _repository.CatDocument.FindAll().ToList();
                        foreach (DtTypeSupplier Supplier in listtypeSuppliers)
                        {
                            List<DtCatDocument> dtDocuments = new List<DtCatDocument>();
                            List<int> idDocuments = _repository.CatDocument.FindByCondition(x => x.IdTypeSupplier.Contains(Supplier.IdTypeSupplier.ToString())).Select(x => x.IdDocument).ToList();
                            foreach (int idDocument in idDocuments)
                            {
                                CatDocument document = listDocuments.SingleOrDefault(x => x.IdDocument == idDocument);
                                if (document != null)
                                {
                                    Supplier.Documents.Add(new DtCatDocument
                                    {
                                        IdDocument = idDocument,
                                        Key = document.Key,
                                        Order = document.Order,
                                        Description = document.Description,
                                        FileMaxLenghtMB = document.FileMaxLenghtMB,
                                        isRequired = document.isRequired,
                                        Extension = document.Extension,
                                        Status = document.Status

                                    });
                                }
                            }

                        }
                        return Ok(listtypeSuppliers);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound);
                    }

                }
                else if (listTokens.Token != token)
                {
                    return StatusCode(StatusCodes.Status404NotFound);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }

        /// <summary>
        /// Obtiene los documentos de soporte existentes para cada proveedor.
        /// </summary>
        [HttpGet]
        [Route("GetDocumentsSupport")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtSupplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetDocumentsSupport()
        {
            try
            {

                string tokenHeaders = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                var count = Convert.ToInt32((tokenHeaders.Length - 7));
                string token = tokenHeaders.Substring(7, count);

                TokenApplication listTokens = _repositoryportal.TokenApplication.FindByCondition(x => x.IdApplication == 5).SingleOrDefault();
                var TokenApplication = listTokens.Token;
                if (TokenApplication == token && listTokens.Status == true)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var JwToken = await Jwt.validarTokenAsync(identity);
                    if (!JwToken.success) return StatusCode(StatusCodes.Status404NotFound);
                    vtPerson Usuario = JwToken.result;
                    if (Usuario.Name == "Administrador" && Usuario.IdPerson == 1)
                    {
                        List<vtSupplier> Suppliers = await _repository.Supplier.GetAllSupplier();
                        if (Suppliers.Count() == 0)
                            return StatusCode(StatusCodes.Status204NoContent, new ProblemDetails { Title = "No se encontraron registros", Status = 204 });

                        List<DtSupplier> listSuppliers = _mapper.Map<List<DtSupplier>>(Suppliers);
                        List<vtDocumentSupplier> listSoports = _repository.DocumentSupplier.FindByCondition(y => y.StatusName.Equals("VALIDADO")).ToList();
                        foreach (DtSupplier Supplier in listSuppliers)
                        {
                            List<DtDocumentSupplier> dtDocuments = new List<DtDocumentSupplier>();
                            List<int> idDocuments = _repository.DocumentSupplier.FindByCondition(x => x.RFC == Supplier.RFC).Select(x => x.IdDocument).ToList();
                            foreach (int idDocument in idDocuments)
                            {
                                vtDocumentSupplier document = listSoports.SingleOrDefault(x => x.IdDocument == idDocument && x.RFC == Supplier.RFC && x.StatusName != "ELIMINADO");
                                if (document != null)
                                {
                                    //string rutaDestino = "C:\\Lupe" + document.Path;
                                    //string rutaDestinoCompleta = Path.Combine(rutaDestino, document.FileName);
                                    //byte[] bytes = System.IO.File.ReadAllBytes(rutaDestinoCompleta);
                                    //var base64String = Convert.ToBase64String(bytes);

                                    Supplier.SupportDocuments.Add(new DtDocumentSupplier
                                    {
                                        IdDocumentSupplier = document.IdDocumentSupplier,
                                        IdDocument = idDocument,
                                        IdPreSupplier = document.IdPreSupplier,
                                        IdTypeSupplier = document.IdTypeSupplier,
                                        Description = document.Description,
                                        isRequired = document.isRequired,
                                        RFC = document.RFC,
                                        StatusName = document.StatusName,
                                        FileName = document.FileName,
                                        Path = document.Path,
                                        CreatedDate = document.CreatedDate,
                                        ValidateByName = document.ValidateByName,
                                        ValidationDate = document.ValidationDate,
                                        //FullAddres = rutaDestinoCompleta,
                                        //FileBase64 = base64String
                                    });
                                }
                            }
                        }
                        return Ok(listSuppliers);

                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound);
                    }

                }
                else if (listTokens.Token != token)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }

        #endregion

    }
}
