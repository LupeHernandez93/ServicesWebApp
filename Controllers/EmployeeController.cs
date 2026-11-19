using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Helpers;
using ServicesWebApp.Interfaces.PortalWebApp;
using ServicesWebApp.Models;
using ServicesWebApp.Models.PortalWebApp;
using System;
using System.Security.Claims;

namespace ServicesWebApp.Controllers
{
    [Route("apiQMAX/[controller]/")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        #region Properties

        private readonly ILogger<EmployeeController> _logger;
        private readonly IPortalRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        #endregion

        #region Methods

        public EmployeeController(ILogger<EmployeeController> logger, IPortalRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        /// <summary>
        /// Sincroniza la informacion de los usuarios en los 2 portales(Antigüo-Nuevo).
        /// </summary>
        /// <returns>La descripcion del puesto actualizado.</returns>
        /// POST: apiQMAX/Employee/Synchronize

        [HttpPost]
        [Route("Synchronize")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Synchronize([FromBody] Object optData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
                int IdPerson = Convert.ToInt32(data.ID_PERSON);
                Guid GuidPosition = data.POSITION_GUID;
                Position position = await _repository.Position.FindByCondition(x => x.Guid == GuidPosition).SingleOrDefaultAsync();
                int IdTypeAccount = Convert.ToInt32(data.ID_TYPE_ACCOUNT);
                int IdCompany = Convert.ToInt32(data.ID_COMPANY);
                Guid GuidBranchCompany = data.BRANCH_COMPANY_GUID;
                BranchCompany branchCompany = await _repository.BranchCompany.FindByCondition(x => x.Guid == GuidBranchCompany).SingleOrDefaultAsync();
                Guid GuidBusiness_Unit = data.BUSINESS_UNIT_GUID;
                BusinessUnit businessUnit = await _repository.BusinessUnit.FindByCondition(x => x.Guid == GuidBusiness_Unit).SingleOrDefaultAsync();
                Guid GuidDepartment = data.DEPARTMENT_GUID;
                Department department = await _repository.Department.FindByCondition(x => x.Guid == GuidDepartment).SingleOrDefaultAsync();
                string Name = data.NAME;
                string FirstName = data.FIRSTNAME;
                string LastName = data.LASTNAME;
                string PhoneNumber = data.PHONE_NUMBER;
                string Email = data.EMAIL;
                string Username = data.USERNAME;
                string Password = data.PASSWORD;
                string PwdTemp = data.PWD_TEMP;
                string Imagen = data.IMAGE;
                string ImagenBase64 = data.IMAGEB64;
                int EmployeeNumber = Convert.ToInt32(data.EMPLOYEE_NUMBER);
                string PersonalMail = data.PERSONAL_MAIL;
                string Curp = data.CURP;
                string Nss = data.NSS;
                string Bloodtype = data.BLOODTYPE;
                DateTime Antiquity = Convert.ToDateTime(data.ANTIQUITY);
                DateTime Stardate = Convert.ToDateTime(data.START_DATE);
                string PersonalPhone = data.PERSONAL_PHONE;
                string EmergencyNumber = data.EMERGENCY_NUMBER;
                string Allergies = data.ALLERGIES;
                int IdCivilStatus = Convert.ToInt32(data.ID_CIVIL_STATUS);
                string Nationality = data.NATIONALITY;
                DateTime Birthdate = Convert.ToDateTime(data.BIRTHDATE);
                int IdImmediateBoss = Convert.ToInt32(data.ID_JEFE_IMMEDIATE);
                Person Immediateboss = await _repository.Person.FindByCondition(x => x.EmployeeNumber == IdImmediateBoss).SingleOrDefaultAsync();
                if (Immediateboss != null)
                { }
                else { }
                //int IdFuntionalBoss = Convert.ToInt32(data.ID_FUNCTIONAL_BOSS);
                //int Funtional_Boss = 0;
                //Person FuntionalBoss = await _repository.Person.FindByCondition(x => x.EmployeeNumber == IdFuntionalBoss).SingleOrDefaultAsync();
                //if (FuntionalBoss != null)
                //{
                //    Funtional_Boss = FuntionalBoss.IdPerson;
                //}
                //else
                //{
                //    Funtional_Boss = 0;
                //}
                DateTime CreatedDate = Convert.ToDateTime(data.CREATED_DATE);
                DateTime ActivationDate = Convert.ToDateTime(data.ACTIVATION_DATE);
                bool IsEmployeeC5M = data.IS_EMPLOYEE_C5M;
                bool Status = data.STATUS;
                string Rfc = data.RFC;
                string Bank = data.BANK;
                string BankAccount = data.BANKACCOUNT;
                string InterbankCode = data.INTERBANKCODE;
                string CorporateNumber = data.CORPORATENUMBER;
                AppSettings appSettings = new AppSettings();
                if (IdPerson == 0)
                {
                    Person personRNew = await _repository.Person.FindByCondition(x => x.Curp == Curp && x.Nss == Nss && x.BloodType== Bloodtype && x.Name == Name).SingleOrDefaultAsync();
                    if (personRNew != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new { Resultado = "El Empleado " + personRNew.Name.ToString() + " A ya se encuentra registrado " });

                    }
                    else
                    {
                        Person person = new Person();
                        person.IdTypeAccount = IdTypeAccount;
                        person.Name = Name;
                        person.FirstName = FirstName;
                        person.LastName = LastName;
                        person.IdCompany = IdCompany;
                        person.IdBranchCompany = branchCompany.IdBranchCompany;
                        person.IdBusinessUnit = businessUnit.IdBusinessUnit;
                        person.IdDepartment = department.IdDepartment;
                        person.IdPosition = position.IdPosition;
                        person.IdImmediateBoss = Immediateboss.IdPerson;
                        /*person.IdFuntionalBoss = (Funtional_Boss != 0 ? Funtional_Boss : null);*/
                        person.EmployeeNumber = EmployeeNumber;
                        person.Curp = Curp;
                        person.Nss = Nss;
                        person.Birthdate = (Birthdate != null ? Birthdate : null);
                        person.StartDateJob = (Stardate != null ? Stardate : DateTime.Now);
                        person.Antiquity = (Antiquity != null ? Antiquity : DateTime.Now);
                        person.BloodType = Bloodtype;
                        person.Allergies = Allergies;
                        person.Nationality = Nationality;
                        person.IdCivilStatus = IdCivilStatus;
                        person.PersonalPhone = PersonalPhone;
                        person.EmergencyNumber = EmergencyNumber;
                        person.PersonalMail = (PersonalMail != null ? PersonalMail.ToLower() : null);
                        person.Email = (Email != null ? Email.ToLower() : null); ;
                        person.Username = Username;//username;
                        person.Password = Password;//password;
                        person.PwdTemp = PwdTemp;//password;
                        person.Rfc= Rfc;
                        person.Bank= Bank;
                        person.BankAccount= BankAccount;
                        person.InterbankCode = InterbankCode;
                        person.CorporateNumber = CorporateNumber;
                        person.CreatedDate = (CreatedDate != null ? CreatedDate : DateTime.Now);
                        person.Status = Status;

                        _repository.Person.Create(person);
                        _repository.Save();

                        string PhysicalDirectoryPhoto = appSettings.PhysicalServerFolder;
                        string filenamePhoto = Imagen;
                        string RutaFile = appSettings.PhysicalServerFolder + filenamePhoto;

                        if (System.IO.File.Exists(RutaFile))
                        {
                            bool response = await ImagenHelper.UpdateAvatarAsync(person.IdPerson, filenamePhoto, ImagenBase64);
                            if (response)
                                person.Image = person.IdPerson.ToString() + ".png";
                        }

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = "El Empleado " + person.Name.ToString() + " A sido agregado y el numero de empleado es " + person.EmployeeNumber + " " });
                    }
                }
                else
                {
                    Person person = await _repository.Person.FindByCondition(x => x.EmployeeNumber == EmployeeNumber).SingleOrDefaultAsync();
                    if (person != null)
                    {
                      var EmailValidate=ValidateEmailForUpdate(Email, person.Email);

                        person.IdTypeAccount = IdTypeAccount;
                        person.Name = Name;
                        person.FirstName = FirstName;
                        person.LastName = LastName;
                        person.IdCompany = IdCompany;
                        person.IdBranchCompany = branchCompany.IdBranchCompany;
                        person.IdBusinessUnit = businessUnit.IdBusinessUnit;
                        person.IdDepartment = department.IdDepartment;
                        person.IdPosition = position.IdPosition;
                        person.IdImmediateBoss = Immediateboss.IdPerson;
                       /* person.IdFuntionalBoss = (Funtional_Boss != 0 ? Funtional_Boss : null);*/
                        person.EmployeeNumber = EmployeeNumber;
                        person.Curp = Curp;
                        person.Nss = Nss;
                        person.Birthdate = (Birthdate != null ? Birthdate : person.Birthdate);
                        person.StartDateJob = (Stardate != null ? Stardate : person.StartDateJob);
                        person.Antiquity = (Antiquity != null ? Antiquity : person.Antiquity);
                        person.BloodType = Bloodtype;
                        person.Allergies = Allergies;
                        person.Nationality = Nationality;
                        person.IdCivilStatus = IdCivilStatus;
                        person.PersonalPhone = PersonalPhone;
                        person.EmergencyNumber = EmergencyNumber;
                        person.PersonalMail = (PersonalMail != null ? PersonalMail.ToLower() : null);
                        // Validación específica para actualización del campo Email:
                        // Si el valor entrante es null, vacío, contiene solo comillas simples ('), o solo comillas dobles (")
                        // mantener el email anterior; en otro caso usar el valor entrante en minúsculas.
                        person.Email = EmailValidate;
                        person.Username = Username;//username;
                        person.Password = Password;//password;
                        person.PwdTemp = PwdTemp;//password;
                        person.Rfc = Rfc;
                        person.Bank = Bank;
                        person.BankAccount = BankAccount;
                        person.InterbankCode = InterbankCode;
                        person.CorporateNumber = CorporateNumber;
                        person.CreatedDate = (CreatedDate != null ? CreatedDate : person.CreatedDate);
                        person.Status = Status;
                        _repository.Person.Update(person);
                        _repository.Save();

                        string PhysicalDirectoryPhoto = appSettings.PhysicalServerFolder;
                        string filenamePhoto = Imagen;
                        string RutaFile = appSettings.PhysicalServerFolder + filenamePhoto;

                        if (System.IO.File.Exists(RutaFile))
                        {
                            bool response = await ImagenHelper.UpdateAvatarAsync(person.IdPerson, filenamePhoto, ImagenBase64);
                            if (response)
                                person.Image = person.IdPerson.ToString() + ".png";
                        }

                        return StatusCode(StatusCodes.Status200OK, new { Resultado = "El Empleado " + person.Name.ToString() + " A sido modificado correctamente" });
                    }
                    else if (person == null && IdPerson != 0)
                    {
                        Person person1 = new Person();
                        person1.IdTypeAccount = IdTypeAccount;
                        person1.Name = Name;
                        person1.FirstName = FirstName;
                        person1.LastName = LastName;
                        person1.IdCompany = IdCompany;
                        person1.IdBranchCompany = branchCompany.IdBranchCompany;
                        person1.IdBusinessUnit = businessUnit.IdBusinessUnit;
                        person1.IdDepartment = department.IdDepartment;
                        person1.IdPosition = position.IdPosition;
                        person1.IdImmediateBoss = Immediateboss.IdPerson;
                       /* person1.IdFuntionalBoss = (Funtional_Boss != 0 ? Funtional_Boss : null);*/
                        person1.EmployeeNumber = EmployeeNumber;
                        person1.Curp = Curp;
                        person1.Nss = Nss;
                        person1.Birthdate = (Birthdate != null ? Birthdate : null);
                        person1.StartDateJob = (Stardate != null ? Stardate : DateTime.Now);
                        person1.Antiquity = (Antiquity != null ? Antiquity : DateTime.Now);
                        person1.BloodType = Bloodtype;
                        person1.Allergies = Allergies;
                        person1.Nationality = Nationality;
                        person1.IdCivilStatus = IdCivilStatus;
                        person1.PersonalPhone = PersonalPhone;
                        person1.EmergencyNumber = EmergencyNumber;
                        person1.PersonalMail = (PersonalMail != null ? PersonalMail.ToLower() : null);
                        person1.Email = (Email != null ? Email.ToLower() : null); ;
                        person1.Username = Username;//username;
                        person1.Password = Password;//password;
                        person1.PwdTemp = PwdTemp;//password;
                        person1.Rfc = Rfc;
                        person1.Bank = Bank;
                        person1.BankAccount = BankAccount;
                        person1.InterbankCode = InterbankCode;
                        person1.CorporateNumber = CorporateNumber;
                        person1.CreatedDate = (CreatedDate != null ? CreatedDate : DateTime.Now);
                        person1.Status = Status;

                        _repository.Person.Create(person1);
                        _repository.Save();

                        string PhysicalDirectoryPhoto = appSettings.PhysicalServerFolder;
                        string filenamePhoto = Imagen;
                        string RutaFile = appSettings.PhysicalServerFolder + filenamePhoto;

                        if (System.IO.File.Exists(RutaFile))
                        {
                            bool response = await ImagenHelper.UpdateAvatarAsync(person1.IdPerson, filenamePhoto, ImagenBase64);
                            if (response)
                                person1.Image = person1.IdPerson.ToString() + ".png";
                        }
                        return StatusCode(StatusCodes.Status200OK, new { Resultado = "El Empleado " + person1.Name.ToString() + " A sido agregado correctamente" });


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
        /// Devuelve una lista de todos los empleados con sus datos.
        /// </summary>
        /// <returns>Una lista de empleados.</returns>
        /// GET: apiC5M/Employee/GetAll
        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                string tokenHeaders = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                var count = Convert.ToInt32((tokenHeaders.Length - 7));
                string token = tokenHeaders.Substring(7, count);

                //ClaimsIdentity identity = new ClaimsIdentity(HttpClien .AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role); = 
                //bool Authenticated = HttpContext.User.Identity.IsAuthenticated;

                TokenApplication listTokens = _repository.TokenApplication.FindByCondition(x => x.IdApplication == 5).SingleOrDefault();
                var TokenApplication = listTokens.Token;
                if (TokenApplication == token && listTokens.Status == true)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var JwToken = await Jwt.validarTokenAsync(identity);
                    if (!JwToken.success) return StatusCode(StatusCodes.Status404NotFound);
                    vtPerson Usuario = JwToken.result;
                    if (Usuario.Name == "Administrador" && Usuario.IdPerson == 1)
                    {
                        List<vtPerson> persons = await _repository.Person.GetAllAsync();
                        if (persons.Count() == 0)
                            return StatusCode(StatusCodes.Status204NoContent, new ProblemDetails { Title = "No se encontraron registros", Status = 204 });

                        List<DtPerson> listPersons = _mapper.Map<List<DtPerson>>(persons);
                        List<Application> listApplications = _repository.Application.FindAll().ToList();
                        foreach (DtPerson person in listPersons)
                        {
                            List<DtApplication> dtApplications = new List<DtApplication>();
                            List<int> idApplications = _repository.PersonApplication.FindByCondition(x => x.IdPerson == person.IdPerson).Select(x => x.IdApplication).ToList();
                            foreach (int idApplication in idApplications)
                            {
                                Application application = listApplications.SingleOrDefault(x => x.IdApplication == idApplication);
                                if (application != null)
                                {
                                    person.Applications.Add(new DtApplication
                                    {
                                        IdApplication = idApplication,
                                        Name = application.Name,
                                        IsActive = application.IsActive,
                                    });
                                }
                            }

                        }
                        return Ok(listPersons);
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
        /// Obtiene los datos del empleado solicitado por parametro.
        /// </summary>
        /// <returns>La entidad empleado.</returns>
        /// GET: apiC5M/Employee/{IdPerson}
        [HttpGet("{IdPerson}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtPerson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int idPerson)
        {
            try
            {
                string tokenHeaders = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                var count = Convert.ToInt32((tokenHeaders.Length - 7));
                string token = tokenHeaders.Substring(7, count);
                //ClaimsIdentity identity = new ClaimsIdentity(HttpClien .AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role); = 
                //bool Authenticated = HttpContext.User.Identity.IsAuthenticated;
                TokenApplication listTokens = _repository.TokenApplication.FindByCondition(x => x.IdApplication == 5).SingleOrDefault();
                var TokenApplication = listTokens.Token;
                if (TokenApplication == token && listTokens.Status == true)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var JwToken = await Jwt.validarTokenAsync(identity);
                    if (!JwToken.success) return StatusCode(StatusCodes.Status404NotFound);
                    vtPerson Usuario = JwToken.result;
                    if (Usuario.Name == "Administrador" && Usuario.IdPerson == 1)
                    {
                        vtPerson person = await _repository.Person.GetPersonAsync(idPerson);
                        if (person == null)
                            return StatusCode(StatusCodes.Status404NotFound, new ProblemDetails { Title = "No se encontro el empleado solicitado", Status = 404 });

                        DtPerson dtPerson = _mapper.Map<DtPerson>(person);
                        List<Application> listApplications = _repository.Application.FindAll().ToList();
                        List<int> idApplications = _repository.PersonApplication.FindByCondition(x => x.IdPerson == idPerson).Select(x => x.IdApplication).ToList();
                        foreach (int idApplication in idApplications)
                        {
                            Application application = listApplications.SingleOrDefault(x => x.IdApplication == idApplication);
                            if (application != null)
                            {
                                dtPerson.Applications.Add(new DtApplication
                                {
                                    IdApplication = idApplication,
                                    Name = application.Name,
                                    IsActive = application.IsActive,
                                });
                            }
                        }
                        return Ok(dtPerson);
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

        private static string ValidateEmailForUpdate(string incomingEmail, string currentEmail)
        {
            // Si es null o solo espacios, conservar el email actual
            if (string.IsNullOrWhiteSpace(incomingEmail)) return currentEmail;

            string trimmed = incomingEmail.Trim();

            // Si la cadena está compuesta únicamente por comillas simples/dobles (ej: "", '' o " o ')
            if (trimmed.All(c => c == '"' || c == '\'')) return currentEmail;

            // Eliminar comillas alrededor si las hubiera (ej: "\"user@x.com\"" -> user@x.com)
            string unquoted = trimmed.Trim('\"', '\'');

            // Si después de quitar comillas queda vacío, conservar el email actual
            if (string.IsNullOrWhiteSpace(unquoted)) return currentEmail;

            // Devolver el valor entrante en minúsculas
            return unquoted.ToLowerInvariant();
        }
        #endregion
    }
}
