using SoftsqChatbotContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            var prevFilename = string.Empty;
            var prevIsclient = false;

            var message = string.Empty;
            string chatter = string.Empty;
            DateTime timestamp = DateTime.Now;
            bool isclient = false;
            string filename = string.Empty;

            List<LogmessagesV3> newresults = new List<LogmessagesV3>();

            using (var db = new SoftsqChatbotDataContext())
            {
                foreach (var item in db.LogmessagesV2s.OrderBy(i => i.ID))
                {
                    if (item.SessionFileName != prevFilename) // New file
                    {
                        // Prepare to save the previous one
                        if (!string.IsNullOrEmpty(message))
                        {
                            newresults.Add(new LogmessagesV3()
                            {
                                Chatter = chatter,
                                ChatTimestamp = timestamp,
                                IsCLient = isclient,
                                Message = message,
                                SessionFileName = filename
                            });

                            //db.LogmessagesV3s.InsertOnSubmit(new LogmessagesV3() {
                            //    Chatter = chatter,
                            //    ChatTimestamp = timestamp,
                            //    IsCLient = isclient,
                            //    Message = message,
                            //    SessionFileName = filename
                            //});
                        }

                        chatter = item.Chatter;
                        timestamp = item.ChatTimestamp;
                        isclient = item.IsClient;
                        message = item.Message;
                        filename = item.SessionFileName;
                    }
                    else // Same file
                    {
                        // Check client's flag
                        if(item.IsClient == prevIsclient)
                        {
                            message += Environment.NewLine + item.Message;
                        }
                        else
                        {
                            //Store a new item
                            newresults.Add(new LogmessagesV3()
                            {
                                Chatter = chatter,
                                ChatTimestamp = timestamp,
                                IsCLient = isclient,
                                Message = message,
                                SessionFileName = filename
                            });

                            chatter = item.Chatter;
                            isclient = item.IsClient;
                            timestamp = item.ChatTimestamp;
                            message = item.Message;
                            filename = item.SessionFileName;
                        }
                    }

                    prevIsclient = item.IsClient;
                    prevFilename = item.SessionFileName;
                }

                newresults.Add(new LogmessagesV3()
                {
                    Chatter = chatter,
                    ChatTimestamp = timestamp,
                    IsCLient = isclient,
                    Message = message,
                    SessionFileName = filename
                });

                db.LogmessagesV3s.InsertAllOnSubmit(newresults);
                db.SubmitChanges();
            }

            label1.Text = newresults.Count.ToString();
        }
    }
}
