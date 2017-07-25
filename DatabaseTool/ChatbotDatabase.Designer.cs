﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 7/21/2017 5:24:38 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace SoftsqChatbotContext
{

    [DatabaseAttribute(Name = "softsq_chatbot")]
    [ProviderAttribute(typeof(Devart.Data.MySql.Linq.Provider.MySqlDataProvider))]
    public partial class SoftsqChatbotDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(SoftsqChatbotDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertChathistory(Chathistory instance);
        partial void UpdateChathistory(Chathistory instance);
        partial void DeleteChathistory(Chathistory instance);
        partial void InsertClientMessage(ClientMessage instance);
        partial void UpdateClientMessage(ClientMessage instance);
        partial void DeleteClientMessage(ClientMessage instance);
        partial void InsertLogmessagesV3(LogmessagesV3 instance);
        partial void UpdateLogmessagesV3(LogmessagesV3 instance);
        partial void DeleteLogmessagesV3(LogmessagesV3 instance);

        #endregion

        public SoftsqChatbotDataContext() :
        base(@"User Id=root;Host=127.0.0.1;Database=softsq_chatbot;Unicode=True;Persist Security Info=True;Character Set=utf8", mappingSource)
        {
            OnCreated();
        }

        public SoftsqChatbotDataContext(MappingSource mappingSource) :
        base(@"User Id=root;Host=127.0.0.1;Database=softsq_chatbot;Unicode=True;Persist Security Info=True;Character Set=utf8", mappingSource)
        {
            OnCreated();
        }

        public SoftsqChatbotDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SoftsqChatbotDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SoftsqChatbotDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public SoftsqChatbotDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Chathistory> Chathistories
        {
            get
            {
                return this.GetTable<Chathistory>();
            }
        }

        public Devart.Data.Linq.Table<ClientMessage> ClientMessages
        {
            get
            {
                return this.GetTable<ClientMessage>();
            }
        }

        public Devart.Data.Linq.Table<Logmessage> Logmessages
        {
            get
            {
                return this.GetTable<Logmessage>();
            }
        }

        public Devart.Data.Linq.Table<LogmessagesV2> LogmessagesV2s
        {
            get
            {
                return this.GetTable<LogmessagesV2>();
            }
        }

        public Devart.Data.Linq.Table<LogmessagesV3> LogmessagesV3s
        {
            get
            {
                return this.GetTable<LogmessagesV3>();
            }
        }
    }
}

namespace SoftsqChatbotContext
{

    /// <summary>
    /// There are no comments for SoftsqChatbotContext.Chathistory in the schema.
    /// </summary>
    [Table(Name = @"softsq_chatbot.chathistories")]
    public partial class Chathistory : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _ID;

        private System.DateTime _ChatTimestamp;

        private string _Chatter;

        private string _Message;

        private string _SessionFileName;

        private bool _IsClient;

        private System.DateTime _ModifiedDate = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnChatTimestampChanging(System.DateTime value);
        partial void OnChatTimestampChanged();
        partial void OnChatterChanging(string value);
        partial void OnChatterChanged();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        partial void OnSessionFileNameChanging(string value);
        partial void OnSessionFileNameChanged();
        partial void OnIsClientChanging(bool value);
        partial void OnIsClientChanged();
        partial void OnModifiedDateChanging(System.DateTime value);
        partial void OnModifiedDateChanged();
        #endregion

        public Chathistory()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ChatTimestamp in the schema.
        /// </summary>
        [Column(Storage = "_ChatTimestamp", CanBeNull = false, DbType = "DATETIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ChatTimestamp
        {
            get
            {
                return this._ChatTimestamp;
            }
            set
            {
                if (this._ChatTimestamp != value)
                {
                    this.OnChatTimestampChanging(value);
                    this.SendPropertyChanging();
                    this._ChatTimestamp = value;
                    this.SendPropertyChanged("ChatTimestamp");
                    this.OnChatTimestampChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Chatter in the schema.
        /// </summary>
        [Column(Storage = "_Chatter", CanBeNull = false, DbType = "VARCHAR(50) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Chatter
        {
            get
            {
                return this._Chatter;
            }
            set
            {
                if (this._Chatter != value)
                {
                    this.OnChatterChanging(value);
                    this.SendPropertyChanging();
                    this._Chatter = value;
                    this.SendPropertyChanged("Chatter");
                    this.OnChatterChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", CanBeNull = false, DbType = "LONGTEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this.OnMessageChanging(value);
                    this.SendPropertyChanging();
                    this._Message = value;
                    this.SendPropertyChanged("Message");
                    this.OnMessageChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SessionFileName in the schema.
        /// </summary>
        [Column(Storage = "_SessionFileName", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string SessionFileName
        {
            get
            {
                return this._SessionFileName;
            }
            set
            {
                if (this._SessionFileName != value)
                {
                    this.OnSessionFileNameChanging(value);
                    this.SendPropertyChanging();
                    this._SessionFileName = value;
                    this.SendPropertyChanged("SessionFileName");
                    this.OnSessionFileNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IsClient in the schema.
        /// </summary>
        [Column(Storage = "_IsClient", CanBeNull = false, DbType = "TINYINT(1) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public bool IsClient
        {
            get
            {
                return this._IsClient;
            }
            set
            {
                if (this._IsClient != value)
                {
                    this.OnIsClientChanging(value);
                    this.SendPropertyChanging();
                    this._IsClient = value;
                    this.SendPropertyChanged("IsClient");
                    this.OnIsClientChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ModifiedDate in the schema.
        /// </summary>
        [Column(Storage = "_ModifiedDate", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ModifiedDate
        {
            get
            {
                return this._ModifiedDate;
            }
            set
            {
                if (this._ModifiedDate != value)
                {
                    this.OnModifiedDateChanging(value);
                    this.SendPropertyChanging();
                    this._ModifiedDate = value;
                    this.SendPropertyChanged("ModifiedDate");
                    this.OnModifiedDateChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for SoftsqChatbotContext.ClientMessage in the schema.
    /// </summary>
    [Table(Name = @"softsq_chatbot.client_messages")]
    public partial class ClientMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _ID;

        private System.DateTime _ChatTimestamp;

        private string _Chatter;

        private string _Message;

        private string _SessionFileName;

        private bool _IsClient;

        private System.DateTime _ModifiedDate = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnChatTimestampChanging(System.DateTime value);
        partial void OnChatTimestampChanged();
        partial void OnChatterChanging(string value);
        partial void OnChatterChanged();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        partial void OnSessionFileNameChanging(string value);
        partial void OnSessionFileNameChanged();
        partial void OnIsClientChanging(bool value);
        partial void OnIsClientChanged();
        partial void OnModifiedDateChanging(System.DateTime value);
        partial void OnModifiedDateChanged();
        #endregion

        public ClientMessage()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ChatTimestamp in the schema.
        /// </summary>
        [Column(Storage = "_ChatTimestamp", CanBeNull = false, DbType = "DATETIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ChatTimestamp
        {
            get
            {
                return this._ChatTimestamp;
            }
            set
            {
                if (this._ChatTimestamp != value)
                {
                    this.OnChatTimestampChanging(value);
                    this.SendPropertyChanging();
                    this._ChatTimestamp = value;
                    this.SendPropertyChanged("ChatTimestamp");
                    this.OnChatTimestampChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Chatter in the schema.
        /// </summary>
        [Column(Storage = "_Chatter", CanBeNull = false, DbType = "VARCHAR(50) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Chatter
        {
            get
            {
                return this._Chatter;
            }
            set
            {
                if (this._Chatter != value)
                {
                    this.OnChatterChanging(value);
                    this.SendPropertyChanging();
                    this._Chatter = value;
                    this.SendPropertyChanged("Chatter");
                    this.OnChatterChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", CanBeNull = false, DbType = "LONGTEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this.OnMessageChanging(value);
                    this.SendPropertyChanging();
                    this._Message = value;
                    this.SendPropertyChanged("Message");
                    this.OnMessageChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SessionFileName in the schema.
        /// </summary>
        [Column(Storage = "_SessionFileName", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string SessionFileName
        {
            get
            {
                return this._SessionFileName;
            }
            set
            {
                if (this._SessionFileName != value)
                {
                    this.OnSessionFileNameChanging(value);
                    this.SendPropertyChanging();
                    this._SessionFileName = value;
                    this.SendPropertyChanged("SessionFileName");
                    this.OnSessionFileNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IsClient in the schema.
        /// </summary>
        [Column(Storage = "_IsClient", CanBeNull = false, DbType = "TINYINT(1) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public bool IsClient
        {
            get
            {
                return this._IsClient;
            }
            set
            {
                if (this._IsClient != value)
                {
                    this.OnIsClientChanging(value);
                    this.SendPropertyChanging();
                    this._IsClient = value;
                    this.SendPropertyChanged("IsClient");
                    this.OnIsClientChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ModifiedDate in the schema.
        /// </summary>
        [Column(Storage = "_ModifiedDate", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ModifiedDate
        {
            get
            {
                return this._ModifiedDate;
            }
            set
            {
                if (this._ModifiedDate != value)
                {
                    this.OnModifiedDateChanging(value);
                    this.SendPropertyChanging();
                    this._ModifiedDate = value;
                    this.SendPropertyChanged("ModifiedDate");
                    this.OnModifiedDateChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for SoftsqChatbotContext.Logmessage in the schema.
    /// </summary>
    [Table(Name = @"softsq_chatbot.logmessages")]
    public partial class Logmessage
    {
        #pragma warning disable 0649

        private string _Message;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        #endregion

        public Logmessage()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", DbType = "LONGTEXT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this._Message = value;
                }
            }
        }
    }

    /// <summary>
    /// There are no comments for SoftsqChatbotContext.LogmessagesV2 in the schema.
    /// </summary>
    [Table(Name = @"softsq_chatbot.logmessages_v2")]
    public partial class LogmessagesV2
    {
        #pragma warning disable 0649

        private int _ID = 0;

        private System.DateTime _ChatTimestamp;

        private string _Chatter;

        private string _Message;

        private string _SessionFileName;

        private bool _IsClient;

        private System.DateTime _ModifiedDate = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnChatTimestampChanging(System.DateTime value);
        partial void OnChatTimestampChanged();
        partial void OnChatterChanging(string value);
        partial void OnChatterChanged();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        partial void OnSessionFileNameChanging(string value);
        partial void OnSessionFileNameChanged();
        partial void OnIsClientChanging(bool value);
        partial void OnIsClientChanged();
        partial void OnModifiedDateChanging(System.DateTime value);
        partial void OnModifiedDateChanged();
        #endregion

        public LogmessagesV2()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        [Column(Storage = "_ID", CanBeNull = false, DbType = "INT(11) NOT NULL", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ChatTimestamp in the schema.
        /// </summary>
        [Column(Storage = "_ChatTimestamp", CanBeNull = false, DbType = "DATETIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ChatTimestamp
        {
            get
            {
                return this._ChatTimestamp;
            }
            set
            {
                if (this._ChatTimestamp != value)
                {
                    this._ChatTimestamp = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Chatter in the schema.
        /// </summary>
        [Column(Storage = "_Chatter", CanBeNull = false, DbType = "VARCHAR(50) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Chatter
        {
            get
            {
                return this._Chatter;
            }
            set
            {
                if (this._Chatter != value)
                {
                    this._Chatter = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", CanBeNull = false, DbType = "LONGTEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this._Message = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SessionFileName in the schema.
        /// </summary>
        [Column(Storage = "_SessionFileName", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string SessionFileName
        {
            get
            {
                return this._SessionFileName;
            }
            set
            {
                if (this._SessionFileName != value)
                {
                    this._SessionFileName = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IsClient in the schema.
        /// </summary>
        [Column(Storage = "_IsClient", CanBeNull = false, DbType = "TINYINT(1) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public bool IsClient
        {
            get
            {
                return this._IsClient;
            }
            set
            {
                if (this._IsClient != value)
                {
                    this._IsClient = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ModifiedDate in the schema.
        /// </summary>
        [Column(Storage = "_ModifiedDate", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ModifiedDate
        {
            get
            {
                return this._ModifiedDate;
            }
            set
            {
                if (this._ModifiedDate != value)
                {
                    this._ModifiedDate = value;
                }
            }
        }
    }

    /// <summary>
    /// There are no comments for SoftsqChatbotContext.LogmessagesV3 in the schema.
    /// </summary>
    [Table(Name = @"softsq_chatbot.logmessages_v3")]
    public partial class LogmessagesV3 : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id = 0;

        private System.DateTime _ChatTimestamp;

        private string _Chatter;

        private string _Message;

        private bool _IsCLient;

        private string _SessionFileName;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnChatTimestampChanging(System.DateTime value);
        partial void OnChatTimestampChanged();
        partial void OnChatterChanging(string value);
        partial void OnChatterChanged();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        partial void OnIsCLientChanging(bool value);
        partial void OnIsCLientChanged();
        partial void OnSessionFileNameChanging(string value);
        partial void OnSessionFileNameChanged();
        #endregion

        public LogmessagesV3()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT(11) NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ChatTimestamp in the schema.
        /// </summary>
        [Column(Storage = "_ChatTimestamp", CanBeNull = false, DbType = "DATETIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ChatTimestamp
        {
            get
            {
                return this._ChatTimestamp;
            }
            set
            {
                if (this._ChatTimestamp != value)
                {
                    this.OnChatTimestampChanging(value);
                    this.SendPropertyChanging();
                    this._ChatTimestamp = value;
                    this.SendPropertyChanged("ChatTimestamp");
                    this.OnChatTimestampChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Chatter in the schema.
        /// </summary>
        [Column(Storage = "_Chatter", CanBeNull = false, DbType = "VARCHAR(50) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Chatter
        {
            get
            {
                return this._Chatter;
            }
            set
            {
                if (this._Chatter != value)
                {
                    this.OnChatterChanging(value);
                    this.SendPropertyChanging();
                    this._Chatter = value;
                    this.SendPropertyChanged("Chatter");
                    this.OnChatterChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", DbType = "TEXT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                if (this._Message != value)
                {
                    this.OnMessageChanging(value);
                    this.SendPropertyChanging();
                    this._Message = value;
                    this.SendPropertyChanged("Message");
                    this.OnMessageChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for IsCLient in the schema.
        /// </summary>
        [Column(Storage = "_IsCLient", CanBeNull = false, DbType = "TINYINT(1) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public bool IsCLient
        {
            get
            {
                return this._IsCLient;
            }
            set
            {
                if (this._IsCLient != value)
                {
                    this.OnIsCLientChanging(value);
                    this.SendPropertyChanging();
                    this._IsCLient = value;
                    this.SendPropertyChanged("IsCLient");
                    this.OnIsCLientChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SessionFileName in the schema.
        /// </summary>
        [Column(Storage = "_SessionFileName", CanBeNull = false, DbType = "TEXT NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string SessionFileName
        {
            get
            {
                return this._SessionFileName;
            }
            set
            {
                if (this._SessionFileName != value)
                {
                    this.OnSessionFileNameChanging(value);
                    this.SendPropertyChanging();
                    this._SessionFileName = value;
                    this.SendPropertyChanged("SessionFileName");
                    this.OnSessionFileNameChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}