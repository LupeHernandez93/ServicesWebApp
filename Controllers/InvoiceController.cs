using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;
using ServicesWebApp.Models.SupplierWebApp;
using ServicesWebApp.Models;
using System.Globalization;
using System.Security.Claims;

namespace ServicesWebApp.Controllers
{
    [Route("apiQMAX/[controller]/")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Properties
        private readonly ILogger<InvoiceController> _logger;
        private readonly IPortalRepositoryWrapper _repositoryportal;
        private readonly ISupplierAppRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Methods
        public InvoiceController(ILogger<InvoiceController> logger, IPortalRepositoryWrapper repositoryportal, ISupplierAppRepositoryWrapper repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mapper = mapper;
            _repositoryportal = repositoryportal;
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }


        /// <summary>
        /// Obtiene una lista facturas con un rango de fechas determinado.
        /// </summary>
        [HttpGet("StartDate={StartDate};EndDate={EndDate};SearchBy={SearchBy};")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtInvoice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetInvoices(string StartDate, string EndDate, string SearchBy)
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
                        int FechaError = 0;
                        var date1 = StartDate;
                        var date2 = EndDate;
                        DateTime dt1 = DateTime.Now;
                        DateTime dt2 = dt1;
                        var culture = CultureInfo.CreateSpecificCulture("es-MX");
                        var styles = DateTimeStyles.None;

                        bool fechaInicio = DateTime.TryParse(date1, culture, styles, out dt1);
                        bool fechaFinal = DateTime.TryParse(date2, culture, styles, out dt2);

                        if (!fechaInicio)
                        {
                            return Ok("{StartDate} no contiene una fecha valida");
                        }
                        if (!fechaFinal)
                        {
                            return Ok("{EndDate} no contiene una fecha valida");
                        }

                        DateTime DateStart = DateTime.Parse(StartDate);
                        if (DateStart.Date.ToString("dd-MM-yyyy") == StartDate)
                            FechaError = 0;
                        else
                        {
                            FechaError = 1;
                            return Ok("{StartDate} no contiene formato de fecha valido");
                        }
                        DateTime DateEnd = DateTime.Parse(EndDate);
                        if (DateEnd.Date.ToString("dd-MM-yyyy") == EndDate)
                            FechaError = 0;
                        else
                        {
                            FechaError = 2;
                            return Ok("{EndDate} no contiene formato de fecha valido");
                        }

                        List<vtInvoice> invoice = new List<vtInvoice>();
                        if (SearchBy == "InvoiceDate")
                        {
                            invoice = await _repository.Invoice.GetInvoiceDateApiAsync(DateStart, DateEnd);
                            if (invoice == null)
                                return StatusCode(StatusCodes.Status404NotFound, new ProblemDetails { Title = "No se encontro el empleado solicitado", Status = 404 });

                            List<DtInvoice> listInvoices = _mapper.Map<List<DtInvoice>>(invoice);

                            return Ok(listInvoices);
                        }
                        else if (SearchBy == "UploadDate")
                        {
                            invoice = await _repository.Invoice.GetInvoiceCreatedAsync(DateStart, DateEnd);
                            if (invoice == null)
                                return StatusCode(StatusCodes.Status404NotFound, new ProblemDetails { Title = "No se encontro el empleado solicitado", Status = 404 });

                            List<DtInvoice> listInvoices = _mapper.Map<List<DtInvoice>>(invoice);

                            return Ok(listInvoices);

                        }
                        else
                        {
                            return Ok("{SearchBy} no contiene un parametro valido");
                        }

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
