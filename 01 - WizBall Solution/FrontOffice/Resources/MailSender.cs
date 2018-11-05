using BusinessLogic.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace FrontOffice.Resources
{
    public static class MailSender
    {


        private static MailMessage ClientMailBuilder(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            MailMessage messageToClient = new MailMessage();
            try
            {
                messageToClient.From = new MailAddress("pftestessrc@gmail.com");
                messageToClient.To.Add(UserEmail);
                messageToClient.BodyEncoding = Encoding.UTF8;
                messageToClient.Subject = MessageSubject;
                messageToClient.Body = string.Format(@"Dear {0},<br /><br />
                                                        You have contacted us from the wizball website with the following message:<br /><br />
                                                              - Subject: {1}<br /><br />
                                                              - Message: {2}<br /><br />
                                                        Thank you for your message! We will check it out as soon as possible.<br /><br />
                                                        We work hard every day so you can always have the results you want in your bets.<br /><br />
                                                        Our best regards,<br/>
                                                        Wizball support team",
                                                        UserName,
                                                        MessageSubject,
                                                        MessageBody
                );

                //Attachment at = new Attachment("~/Attachments/txt.doc");

                if (!(attachments is null))
                {
                    foreach (Attachment attachment in attachments)
                    {
                        messageToClient.Attachments.Add(attachment);
                    }
                }


                messageToClient.Priority = MailPriority.High;
                messageToClient.IsBodyHtml = true;

                //prepare to send mail via SMTP transport


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return messageToClient;
        }




        private static MailMessage ServerMailBuilder(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            MailMessage messageToServer = new MailMessage("pftestessrc@gmail.com", "pftestesdepo@gmail.com");
            try
            {
                messageToServer.To.Add(UserEmail);
                messageToServer.BodyEncoding = Encoding.UTF8;
                messageToServer.Subject = MessageSubject;
                messageToServer.Body = string.Format(@"Dear {0},<br /><br />
                                                        You have contacted us from the wizball website with the following message:<br /><br />
                                                              - Subject: {1}<br /><br />
                                                              - Message: {2}<br /><br />
                                                        Thank you for your message! We will check it out as soon as possible.<br /><br />
                                                        We work hard every day so you can always have the results you want in your bets.<br /><br />
                                                        Our best regards,<br/>
                                                        Wizball support team",
                                                        UserName,
                                                        MessageSubject,
                                                        MessageBody
                );

                //Attachment at = new Attachment("~/Attachments/txt.doc");
                if (!(attachments is null))
                {
                    foreach (Attachment attachment in attachments)
                    {
                        messageToServer.Attachments.Add(attachment);
                    }
                }

                messageToServer.Priority = MailPriority.High;
                messageToServer.IsBodyHtml = true;

                return messageToServer;

            }
            catch (Exception ex)
            {
                return messageToServer;
            }

        }

        public static bool MakeMails(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            try
            {
                BLL bll = new Globals().CreateBll();
                MailMessage ClientMessage = ClientMailBuilder(UserEmail, UserName, MessageSubject, MessageBody, attachments);
                bll.SendEmail(ClientMessage);

                MailMessage ServerMessage = ServerMailBuilder(UserEmail, UserName, MessageSubject, MessageBody, attachments);
                bll.SendEmail(ServerMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}