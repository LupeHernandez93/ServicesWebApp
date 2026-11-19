using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using ServicesWebApp.Models;
using ServicesWebApp.Models.PortalWebApp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServicesWebApp.Controllers
{
    [Route("apiQMAX/[controller]/")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        #region Properties

        private readonly ILogger<CatalogsController> _logger;
        private readonly IPortalRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        #endregion

        #region Methods

        public CatalogsController(ILogger<CatalogsController> logger, IPortalRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Sincroniza el catalogo de los puestos de los dos portales(Antigüo-Nuevo).
        /// </summary>
        /// <returns>La descripcion del puesto actualizado.</returns>
        /// POST: apiQMAX/Catalogs/Position

        [HttpPost]
        [Route("Position")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Position([FromBody] Object optData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
                int IdPuesto = Convert.ToInt32(data.ID_PUESTO);
                int IdCompany = Convert.ToInt32(data.ID_COMPANY);
                string description = data.DESCRIPCION.ToString();
                bool status = Convert.ToBoolean(Convert.ToInt32(data.STATUS));
                Guid Guid = data.GUID;
                if (IdPuesto == 0)
                {
                    
                    Position position = new Position();
                    position.IdCompany = IdCompany;
                    position.Description = description;
                    position.Status = status;
                    position.Guid = Guid;
                    _repository.Position.Create(position);
                    _repository.Save();

                    return StatusCode(StatusCodes.Status200OK, new { Resultado = "El puesto " + position.Description.ToString() + " A sido agregado y el GUID es " + position.Guid.ToString() + " " });
                }
                else
                {
                    Position position = await _repository.Position.FindByCondition(x => x.Guid == Guid).SingleOrDefaultAsync();
                    if (position != null)
                    {
                        position.Description = description;
                        position.Status = status;
                        position.Guid = Guid;
                        _repository.Position.Update(position);
                        _repository.Save();

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = position.Description.ToString() });
                    }
                    else if (position == null)
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "El puesto no se ha encontrado." });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "Verificar los parametros." });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }

        /// <summary>
        /// Sincroniza el catalogo de las unidades de negocios de los dos portales(Antigüo-Nuevo).
        /// </summary>
        /// <returns>La descripcion del puesto actualizado.</returns>
        /// POST: apiQMAX/Catalogs/BusinessUnit

        [HttpPost]
        [Route("BusinessUnit")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BusinessUnit([FromBody] Object optData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
                int IdBusinessUnit = Convert.ToInt32(data.ID_UNE);
                int IdCompany = Convert.ToInt32(data.ID_COMPANY);
                string description = data.DESCRIPCION.ToString();
                string NickName=data.CVE_UNE.ToString();
                bool status = Convert.ToBoolean(Convert.ToInt32(data.STATUS));
                Guid Guid = data.GUID;
                if (IdBusinessUnit == 0)
                {
                    BusinessUnit businessUnit = new BusinessUnit();
                    businessUnit.IdCompany= IdCompany;
                    businessUnit.Name= description;
                    businessUnit.Nickname = NickName;
                    businessUnit.Status= status;
                    businessUnit.Guid= Guid;

                    _repository.BusinessUnit.Create(businessUnit);
                    _repository.Save();

                    return StatusCode(StatusCodes.Status200OK, new { Resultado = "La unida de Negocios " + businessUnit.Name.ToString() + " A sido agregada y el GUID es " + businessUnit.Guid.ToString() + " " });
                }
                else
                {
                    BusinessUnit businessUnit = await _repository.BusinessUnit.FindByCondition(x => x.Guid == Guid).SingleOrDefaultAsync();
                    if (businessUnit != null)
                    {
                        businessUnit.Name = description;
                        businessUnit.Nickname = NickName;
                        businessUnit.Status = status;
                        businessUnit.Guid = Guid;
                        _repository.BusinessUnit.Update(businessUnit);
                        _repository.Save();

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = businessUnit.Name.ToString() });
                    }
                    else if (businessUnit == null)
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "La unidad de negocios no se ha encontrado." });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "Verificar los parametros." });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }



        /// <summary>
        /// Sincroniza el catalogo de las sucursales o compañias de los dos portales(Antigüo-Nuevo).
        /// </summary>
        /// <returns>La descripcion de la sucursal actualizado.</returns>
        /// POST: apiQMAX/Catalogs/BranchCompany
        [HttpPost]
        [Route("BranchCompany")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BranchCompany([FromBody] Object optData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
                int IdBranchCompany = Convert.ToInt32(data.ID_EMPRESA);
                int IdCompany = Convert.ToInt32(data.ID_COMPANY);
                string Rfc = data.RFC.ToString();
                string Name = data.DESCRIPCION.ToString();
                string NickName = data.SHORTNAME.ToString();
                bool IsDefault = Convert.ToBoolean(Convert.ToInt32(data.IS_DEFAULT));
                bool Status = Convert.ToBoolean(Convert.ToInt32(data.STATUS));
                Guid Guid = data.GUID;
                if (IdBranchCompany == 0)
                {
                    BranchCompany branchCompany = new BranchCompany();
                    branchCompany.IdCompany = IdCompany;
                    branchCompany.Name = Name;
                    branchCompany.Nickname = NickName;
                    branchCompany.RFC = Rfc;
                    branchCompany.Status = Status;
                    branchCompany.isDefault = IsDefault;
                    branchCompany.Guid = Guid;

                    _repository.BranchCompany.Create(branchCompany);
                    _repository.Save();

                    return StatusCode(StatusCodes.Status200OK, new { Resultado = "La sucursal " + branchCompany.Name.ToString() + " A sido agregada y el GUID es " + branchCompany.Guid.ToString() + " " });
                }
                else
                {
                    BranchCompany branchCompany = await _repository.BranchCompany.FindByCondition(x => x.Guid == Guid).SingleOrDefaultAsync();
                    if (branchCompany != null)
                    {
                        branchCompany.IdCompany = IdCompany;
                        branchCompany.Name = Name;
                        if (branchCompany.Nickname != null)
                            branchCompany.Nickname = branchCompany.Nickname;
                        else branchCompany.Nickname = NickName;
                        if (branchCompany.RFC != null)
                            branchCompany.RFC = branchCompany.RFC;
                        else branchCompany.RFC = Rfc;
                        branchCompany.Status = Status;
                        branchCompany.isDefault = IsDefault;
                        branchCompany.Guid = Guid;

                        _repository.BranchCompany.Update(branchCompany);
                        _repository.Save();

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = branchCompany.Name.ToString() });
                    }
                    else if (branchCompany == null)
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "La Sucursal no se ha encontrado." });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "Verificar los parametros." });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails { Title = ex.Message, Detail = ex.InnerException.StackTrace, Instance = ex.InnerException.Source, Status = 500 });
            }
        }


        /// <summary>
        /// Sincroniza el catalogo de los departamentos de los dos portales(Antigüo-Nuevo).
        /// </summary>
        /// <returns>La descripcion del puesto actualizado.</returns>
        /// POST: apiQMAX/Catalogs/Departaments

        [HttpPost]
        [Route("Departaments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Departaments([FromBody] Object optData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
                int IdDepartment = Convert.ToInt32(data.ID_DEPARTAMENT);
                int IdCompany = Convert.ToInt32(data.ID_COMPANY);
                string IdCostCenter = data.ID_COSTCENTER.ToString();
                string Classification = data.AREA.ToString();
                string AccountingGroup = data.GROUP_ACCOUNT.ToString();
                string Description = data.DESCRIPTION.ToString();
                bool Status = Convert.ToBoolean(Convert.ToInt32(data.STATUS));
                Guid Guid = data.GUID;
                if (IdDepartment == 0)
                {
                    Department departaments = new Department();
                    departaments.IdCompany = IdCompany;
                    departaments.IdCostCenter = IdCostCenter;
                    departaments.Classification = Classification;
                    departaments.AccountingGroup = AccountingGroup;
                    departaments.Description = Description;
                    departaments.Status = Status;
                    departaments.Guid = Guid;

                    _repository.Department.Create(departaments);
                    _repository.Save();

                    return StatusCode(StatusCodes.Status200OK, new { Resultado = "El departamento " + departaments.Description.ToString() + " A sido agregado y el GUID es " + departaments.Guid.ToString() + " " });
                }
                else
                {
                    Department department = await _repository.Department.FindByCondition(x => x.Guid == Guid).SingleOrDefaultAsync();
                    if (department != null)
                    {
                        department.IdCompany = IdCompany;
                        department.IdCostCenter = IdCostCenter;
                        department.Classification = Classification;
                        department.AccountingGroup = AccountingGroup;
                        department.Description = Description;
                        department.Status = Status;
                        department.Guid = Guid;

                        _repository.Department.Update(department);
                        _repository.Save();

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = department.Description.ToString() });
                    }
                    else if (department == null)
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "El departamento no se ha encontrado." });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { Resultado = "Verificar los parametros." });
                    }
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