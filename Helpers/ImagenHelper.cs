using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.PortalWebApp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
namespace ServicesWebApp.Helpers
{
    public class ImagenHelper
    {

        public static async Task<bool> UpdateAvatarAsync(int idPerson, string imagenfile, string imagenBase64)
        {
            try
            {
                AppSettings appSettings = new AppSettings();
                using (PortalRepositoryContext context = new PortalRepositoryContext())
                {
                    // Rutas base (usando Path.Combine para mayor robustez)
                    string physicalServerFolder = appSettings.PhysicalServerFolder ?? string.Empty; // donde viene el archivo temporal/subido
                    string physicalFilesRoot = appSettings.PhysicalServerFiles ?? string.Empty;    // donde se guardan los archivos finales
                    string assetsTeamDir = Path.Combine(physicalFilesRoot, "assets", "img", "team");

                    // Ruta del archivo fuente que llegó (imagenfile puede ser un nombre de archivo)
                    string incomingPath = Path.Combine(physicalServerFolder, imagenfile ?? string.Empty);

                    // Verificar existencia del archivo entrante
                    if (!File.Exists(incomingPath))
                    {
                        // No existe el archivo entrante: nada que hacer
                        return false;
                    }

                    Person person = await context.Persons.SingleOrDefaultAsync(x => x.IdPerson == idPerson);
                    if (person == null)
                    {
                        return false;
                    }

                    // Obtener base64 entrante preferentemente desde el parámetro; si no, calcularlo desde el archivo
                    string incomingBase64 = imagenBase64;
                    if (string.IsNullOrWhiteSpace(incomingBase64))
                    {
                        incomingBase64 = ConvertImageToBase64String(incomingPath) ?? string.Empty;
                    }

                    // Archivo existente del usuario (si lo tiene)
                    string existingFileName = person.Image;
                    string existingPath = !string.IsNullOrEmpty(existingFileName) ? Path.Combine(assetsTeamDir, existingFileName) : null;
                    string existingBase64 = string.Empty;
                    if (!string.IsNullOrEmpty(existingPath) && File.Exists(existingPath))
                    {
                        existingBase64 = ConvertImageToBase64String(existingPath) ?? string.Empty;
                    }

                    // Si existe imagen previa y es igual a la entrante, no hacer cambios
                    if (!string.IsNullOrEmpty(existingBase64) && !string.IsNullOrEmpty(incomingBase64))
                    {
                        if (CompareBase64Strings(incomingBase64, existingBase64))
                        {
                            // Ya son la misma imagen; nada que actualizar
                            return true;
                        }
                    }

                    // A estas alturas: o no existe imagen previa, o es diferente -> reemplazar/guardar como PNG
                    // Asegurar que el directorio destino exista
                    if (!Directory.Exists(assetsTeamDir))
                    {
                        Directory.CreateDirectory(assetsTeamDir);
                    }

                    string targetFileName = person.IdPerson.ToString() + ".png";
                    string targetPath = Path.Combine(assetsTeamDir, targetFileName);

                    // Intentar convertir a PNG y guardar
                    using (var fileStream = new FileStream(incomingPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var image = Image.FromStream(fileStream))
                        {
                            // Si ya existía, eliminar la anterior (solo si existe y ruta distinta)
                            if (!string.IsNullOrEmpty(existingPath) && File.Exists(existingPath) && !string.Equals(existingPath, targetPath, StringComparison.OrdinalIgnoreCase))
                            {
                                try
                                {
                                    File.Delete(existingPath);
                                }
                                catch
                                {
                                    // ignorar fallo al borrar — proceder a sobrescribir
                                }
                            }

                            // Guardar siempre como PNG para estandarizar
                            image.Save(targetPath, ImageFormat.Png);
                        }
                    }

                    // Actualizar entidad y persistir
                    person.Image = targetFileName;
                    context.Entry(person).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                // Mantener la excepción para diagnóstico en capas superiores
                throw;
            }
        }

        public static string ConvertImageToBase64String(string imagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                    return string.Empty;

                using (var b = new Bitmap(imagePath))
                {
                    using (var ms = new MemoryStream())
                    {
                        b.Save(ms, ImageFormat.Png);
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        static bool CompareBase64Strings(string base64String1, string base64String2)
        {
            if (string.IsNullOrEmpty(base64String1) || string.IsNullOrEmpty(base64String2))
                return false;

            // Normalizar posibles paddings y espacios
            string s1 = base64String1.Trim();
            string s2 = base64String2.Trim();
            if (s1.Equals(s2, StringComparison.Ordinal))
                return true;

            try
            {
                byte[] bytes1 = Convert.FromBase64String(s1);
                byte[] bytes2 = Convert.FromBase64String(s2);

                if (bytes1.Length != bytes2.Length) return false;
                for (int i = 0; i < bytes1.Length; i++)
                {
                    if (bytes1[i] != bytes2[i]) return false;
                }
                return true;
            }
            catch
            {
                // Si no son Base64 válidos, comparar como string
                return s1.Equals(s2, StringComparison.Ordinal);
            }
        }

        public static IFormFile ConvertStringToIFormFile(string content, string fileName)
        {
            // Convertir el string a un array de bytes
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            // Crear un MemoryStream a partir del array de bytes
            var stream = new MemoryStream(byteArray);
            // Crear un FormFile utilizando el MemoryStream
            IFormFile formFile = new FormFile(stream, 0, byteArray.Length, "name", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };
            return formFile;
        }


        //public static async Task<bool> UpdateAvatarAsync(int idPerson, string imagenfile, string imagenBase64)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        using (PortalRepositoryContext context = new PortalRepositoryContext())
        //        {
        //            FileInfo ImagenOriginal = new FileInfo(imagenfile);
        //            FormFile avatarFile2;
        //            Person person = await context.Persons.SingleOrDefaultAsync(x => x.IdPerson == idPerson);
        //            string imagenPersonB64 = "";
        //            string imagenDefault = "";
        //            if (person.Image != null)
        //            {
        //                imagenDefault = appSettings.PhysicalServerFiles + "assets\\img\\team\\" + person.Image.ToString();
        //                if (System.IO.File.Exists(imagenDefault))
        //                {
        //                    imagenPersonB64 = ConvertImageToBase64String(imagenDefault);
        //                }
        //            }

        //            string PhysicalDirectory = appSettings.PhysicalServerFiles + "assets\\img\\team\\";
        //            string extension = ImagenOriginal.Extension;
        //            string PhysicalDirectoryPhoto = appSettings.PhysicalServerFolder;
        //            string Imagen = appSettings.PhysicalServerFolder + imagenfile;
        //            string filename = person.IdPerson.ToString() + extension;
        //            string DirectoryFinal = PhysicalDirectory + filename;
        //            //IFormFile avatarFile2 = ConvertStringToIFormFile(Imagen, filename);
        //            FileStream stream = new FileStream(PhysicalDirectory + filename, FileMode.OpenOrCreate);
        //            using (var fs = stream)
        //            {
        //                avatarFile2 = new FormFile(fs, 0, fs.Length, "name", stream.Name);
        //            }
        //            string extension2 = Path.GetExtension(avatarFile2.FileName).ToLower(); 

        //            if (System.IO.File.Exists(Imagen))
        //            {
        //                if (person.Image != null)
        //                {
        //                    bool IsEquals = CompareBase64Strings(imagenBase64, imagenPersonB64);
        //                    if (IsEquals == true)
        //                    {
        //                        person.Image = person.Image;
        //                        await context.SaveChangesAsync();
        //                    }
        //                    else
        //                    {
        //                        if (File.Exists(imagenDefault))
        //                        {
        //                            File.Delete(imagenDefault);
        //                        }

        //                        if ((extension2.Equals(".jpg")) | (extension2.Equals(".jpg")))
        //                        {
        //                            byte[] imageBytes;
        //                            byte[] fileByteArray = System.IO.File.ReadAllBytes(Imagen);

        //                            using (var ms = new MemoryStream(fileByteArray))
        //                            {
        //                                using (var targetMs = new MemoryStream())
        //                                {
        //                                    using (Image image = Image.FromStream(ms))
        //                                    {
        //                                        image.Save(targetMs, ImageFormat.Png);
        //                                        imageBytes = ms.ToArray();
        //                                    }
        //                                }
        //                                ms.Seek(0, SeekOrigin.Begin);
        //                                using (var fs = new FileStream(PhysicalDirectory + person.IdPerson.ToString() + ".png", FileMode.OpenOrCreate))
        //                                {
        //                                    ms.CopyTo(fs);
        //                                }
        //                            }
        //                            person.Image = person.IdPerson.ToString() + ".png";
        //                            context.Entry(person).State = EntityState.Modified;
        //                            await context.SaveChangesAsync();


        //                        }
        //                        else
        //                        {
        //                            byte[] fileByteArray = System.IO.File.ReadAllBytes(Imagen);
        //                            using (var ms = new MemoryStream(fileByteArray))
        //                            {
        //                                ms.Seek(0, SeekOrigin.Begin);
        //                                using (var fs = new FileStream(PhysicalDirectory + filename, FileMode.OpenOrCreate))
        //                                {
        //                                    ms.CopyTo(fs);
        //                                }
        //                                person.Image = person.IdPerson.ToString() + ".png";
        //                                context.Entry(person).State = EntityState.Modified;
        //                                await context.SaveChangesAsync();
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if ((extension2.Equals(".jpg")) | (extension2.Equals(".jpg")))
        //                    {
        //                        byte[] imageBytes;
        //                        byte[] fileByteArray = System.IO.File.ReadAllBytes(Imagen);

        //                        using (var ms = new MemoryStream(fileByteArray))
        //                        {
        //                            using (var targetMs = new MemoryStream())
        //                            {
        //                                using (Image image = Image.FromStream(ms))
        //                                {
        //                                    image.Save(targetMs, ImageFormat.Png);
        //                                    imageBytes = ms.ToArray();
        //                                }
        //                            }
        //                            ms.Seek(0, SeekOrigin.Begin);
        //                            using (var fs = new FileStream(PhysicalDirectory + person.IdPerson.ToString() + ".png", FileMode.OpenOrCreate))
        //                            {
        //                                ms.CopyTo(fs);
        //                            }
        //                        }
        //                        person.Image = person.IdPerson.ToString() + ".png";
        //                        context.Entry(person).State = EntityState.Modified;
        //                        await context.SaveChangesAsync();
        //                    }
        //                    else
        //                    {
        //                        byte[] fileByteArray = System.IO.File.ReadAllBytes(Imagen);
        //                        using (var ms = new MemoryStream(fileByteArray))
        //                        {
        //                            ms.Seek(0, SeekOrigin.Begin);
        //                            using (var fs = new FileStream(PhysicalDirectory + filename, FileMode.OpenOrCreate))
        //                            {
        //                                ms.CopyTo(fs);
        //                            }
        //                            person.Image = person.IdPerson.ToString() + ".png";
        //                            context.Entry(person).State = EntityState.Modified;
        //                            await context.SaveChangesAsync();
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {


        //                //File.Copy(Imagen, DirectoryFinal, true);
        //                //person.Image = person.IdPerson.ToString() + extension;
        //                //context.Entry(person).State = EntityState.Modified;
        //                //await context.SaveChangesAsync();
        //            }
        //            if (File.Exists(avatarFile2.FileName))
        //            {
        //                File.Delete(avatarFile2.FileName);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static string ConvertImageToBase64String(string imagePath)
        //{
        //    string result = null;
        //    if (!string.IsNullOrEmpty(imagePath))
        //    {
        //        using (var b = new Bitmap(imagePath))
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                b.Save(ms, ImageFormat.Png);
        //                result = Convert.ToBase64String(ms.ToArray());
        //            }
        //        }
        //    }
        //    return result;
        //}

        //static bool CompareBase64Strings(string base64String1, string base64String2)
        //{
        //    // Convertir las cadenas Base64 a bytes
        //    byte[] bytes1 = Convert.FromBase64String(base64String1);
        //    byte[] bytes2 = Convert.FromBase64String(base64String2);

        //    // Comparar los arreglos de bytes
        //    if (bytes1.Length != bytes2.Length)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < bytes1.Length; i++)
        //    {
        //        if (bytes1[i] != bytes2[i])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public static IFormFile ConvertStringToIFormFile(string content, string fileName)
        //{
        //    // Convertir el string a un array de bytes
        //    byte[] byteArray = Encoding.UTF8.GetBytes(content);
        //    // Crear un MemoryStream a partir del array de bytes
        //    using (var stream = new MemoryStream(byteArray))
        //    {
        //        // Crear un FormFile utilizando el MemoryStream
        //        IFormFile formFile = new FormFile(stream, 0, byteArray.Length, "name", fileName)
        //        {
        //            Headers = new HeaderDictionary(),
        //            ContentType = "text/plain"
        //        };
        //        return formFile;
        //    }
        //}

    }
}