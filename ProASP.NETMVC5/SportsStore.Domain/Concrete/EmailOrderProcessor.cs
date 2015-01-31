using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public String MailToAddress = "orders@example.com";
        public String MailFromAddress = "sportsstore@example.com";
        public bool UseSsl = true;
        public String Username = "MySmtpUsername";
        public String Password = "MySmtpPassword";
        public String ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public String FileLocation = @"C:\sports_store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings m_emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings)
        {
            m_emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = m_emailSettings.UseSsl;
                smtpClient.Host = m_emailSettings.ServerName;
                smtpClient.Port = m_emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials =
                    new NetworkCredential(m_emailSettings.Username, m_emailSettings.Password);

                if (m_emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = m_emailSettings.FileLocation;
                    if (!System.IO.Directory.Exists(m_emailSettings.FileLocation))
                        System.IO.Directory.CreateDirectory(m_emailSettings.FileLocation);
                    smtpClient.EnableSsl = false;
                }

                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine("A new order has been submitted");
                bodyBuilder.AppendLine("---");
                bodyBuilder.AppendLine("Items:");

                foreach (var cartLine in cart.Lines)
                {
                    var subtotal = cartLine.Product.Price * cartLine.Quantity;
                    bodyBuilder.AppendFormat("{0} x {1} (subtotal: {2:c}", cartLine.Quantity, cartLine.Product.Name, subtotal);
                }

                bodyBuilder.AppendLine("---");
                bodyBuilder.AppendLine("Ship to:");
                bodyBuilder.AppendLine(shippingDetails.Name);
                bodyBuilder.AppendLine(shippingDetails.Line1);
                bodyBuilder.AppendLine(shippingDetails.Line2 ?? "");
                bodyBuilder.AppendLine(shippingDetails.Line3 ?? "");
                bodyBuilder.AppendLine(shippingDetails.City);
                bodyBuilder.AppendLine(shippingDetails.State ?? "");
                bodyBuilder.AppendLine(shippingDetails.Country);
                bodyBuilder.AppendLine(shippingDetails.Zip);
                bodyBuilder.AppendLine("---");
                bodyBuilder.AppendFormat("Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    m_emailSettings.MailFromAddress,
                    m_emailSettings.MailToAddress,
                    "New order submitted!",
                    bodyBuilder.ToString());

                if (m_emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
