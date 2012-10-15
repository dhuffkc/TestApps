namespace TestVersioning.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using TestVersioning.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new versioningEntities())
            {
                var messages = context.SimplifiedMessages.ToList();
                var query = from m in messages
                            select new SimplifiedMessageEncrypted
                                    {
                                        Id = m.Id,
                                        Number = m.Number,
                                        Created = m.Created,
                                        Version = m.Version,
                                        Modified = m.Modified,
                                        EncryptedVersion = this.Encrypt(m.Version)
                                    };

                return this.View(query.ToList());
            }
        }

        [HttpGet]
        public ActionResult GetMessages()
        {
            using (var context = new versioningEntities())
            {
                var messages = context.SimplifiedMessages.ToList();
                var query = from m in messages
                            select new SimplifiedMessageEncrypted
                            {
                                Id = m.Id,
                                Number = m.Number,
                                Created = m.Created,
                                Version = m.Version,
                                Modified = m.Modified,
                                EncryptedVersion = this.Encrypt(m.Version)
                            };

                return this.Json(query.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PostMessageModified(int messageId, string version)
        {
            var versionEncryptedBytes = MachineKeySectionWrapper.HexStringToByteArray(version);
            var versionBytes = MachineKeySectionWrapper.Decrypt(versionEncryptedBytes);

            var yesterday = DateTime.Now.AddDays(-1);

            var message = new SimplifiedMessage
                {
                    Id = messageId,
                    Version = versionBytes,
                    Created = yesterday,
                    Modified = yesterday,
                    Number = yesterday.Millisecond.ToString()
                };

            try
            {
                MessageRepository.UpdateMessage(message);
            }
            catch (ConcurrencyException)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError, "Concurrency error");
            }

            return this.Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return this.View();
        }

        private string Encrypt(byte[] versionBytes)
        {
            var cipherBytes = MachineKeySectionWrapper.Encrypt(versionBytes);
            var hex = MachineKeySectionWrapper.ByteArrayToHexString(cipherBytes);
            return hex;
        }
    }
}
