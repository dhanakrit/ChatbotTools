﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 7/24/2017 5:52:05 PM
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

namespace ChatLogContext
{

    [DatabaseAttribute(Name = "test_chatbot")]
    [ProviderAttribute(typeof(Devart.Data.SqlServer.Linq.Provider.SqlDataProvider))]
    public partial class ChatLogDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(ChatLogDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertCategory(Category instance);
        partial void UpdateCategory(Category instance);
        partial void DeleteCategory(Category instance);
        partial void InsertClassifiedMessage(ClassifiedMessage instance);
        partial void UpdateClassifiedMessage(ClassifiedMessage instance);
        partial void DeleteClassifiedMessage(ClassifiedMessage instance);
        partial void InsertLogMessage(LogMessage instance);
        partial void UpdateLogMessage(LogMessage instance);
        partial void DeleteLogMessage(LogMessage instance);

        #endregion

        public ChatLogDataContext() :
        base(GetConnectionString("ChatLogDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public ChatLogDataContext(MappingSource mappingSource) :
        base(GetConnectionString("ChatLogDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        public ChatLogDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public ChatLogDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public ChatLogDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public ChatLogDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Category> Categories
        {
            get
            {
                return this.GetTable<Category>();
            }
        }

        public Devart.Data.Linq.Table<ClassifiedMessage> ClassifiedMessages
        {
            get
            {
                return this.GetTable<ClassifiedMessage>();
            }
        }

        public Devart.Data.Linq.Table<LogMessage> LogMessages
        {
            get
            {
                return this.GetTable<LogMessage>();
            }
        }
    }
}

namespace ChatLogContext
{

    /// <summary>
    /// There are no comments for ChatLogContext.Category in the schema.
    /// </summary>
    [Table(Name = @"dbo.Categories")]
    public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _CategoryName;

        private System.Nullable<System.DateTime> _ModifiedDate = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
        partial void OnModifiedDateChanged();
        #endregion

        public Category()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
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
        /// There are no comments for CategoryName in the schema.
        /// </summary>
        [Column(Storage = "_CategoryName", DbType = "NVARCHAR(50)", UpdateCheck = UpdateCheck.Never)]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                if (this._CategoryName != value)
                {
                    this.OnCategoryNameChanging(value);
                    this.SendPropertyChanging();
                    this._CategoryName = value;
                    this.SendPropertyChanged("CategoryName");
                    this.OnCategoryNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ModifiedDate in the schema.
        /// </summary>
        [Column(Storage = "_ModifiedDate", DbType = "DATETIME", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> ModifiedDate
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
    /// There are no comments for ChatLogContext.ClassifiedMessage in the schema.
    /// </summary>
    [Table(Name = @"dbo.ClassifiedMessages")]
    public partial class ClassifiedMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _MessageId;

        private System.Nullable<int> _CategoryId;

        private System.Nullable<int> _SecondCategoryId = 0;

        private string _SelectedCategories;

        private System.Nullable<System.DateTime> _DateModified = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnMessageIdChanging(int value);
        partial void OnMessageIdChanged();
        partial void OnCategoryIdChanging(System.Nullable<int> value);
        partial void OnCategoryIdChanged();
        partial void OnSecondCategoryIdChanging(System.Nullable<int> value);
        partial void OnSecondCategoryIdChanged();
        partial void OnSelectedCategoriesChanging(string value);
        partial void OnSelectedCategoriesChanged();
        partial void OnDateModifiedChanging(System.Nullable<System.DateTime> value);
        partial void OnDateModifiedChanged();
        #endregion

        public ClassifiedMessage()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for MessageId in the schema.
        /// </summary>
        [Column(Storage = "_MessageId", CanBeNull = false, DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int MessageId
        {
            get
            {
                return this._MessageId;
            }
            set
            {
                if (this._MessageId != value)
                {
                    this.OnMessageIdChanging(value);
                    this.SendPropertyChanging();
                    this._MessageId = value;
                    this.SendPropertyChanged("MessageId");
                    this.OnMessageIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for CategoryId in the schema.
        /// </summary>
        [Column(Storage = "_CategoryId", DbType = "INT", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> CategoryId
        {
            get
            {
                return this._CategoryId;
            }
            set
            {
                if (this._CategoryId != value)
                {
                    this.OnCategoryIdChanging(value);
                    this.SendPropertyChanging();
                    this._CategoryId = value;
                    this.SendPropertyChanged("CategoryId");
                    this.OnCategoryIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SecondCategoryId in the schema.
        /// </summary>
        [Column(Storage = "_SecondCategoryId", DbType = "INT", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> SecondCategoryId
        {
            get
            {
                return this._SecondCategoryId;
            }
            set
            {
                if (this._SecondCategoryId != value)
                {
                    this.OnSecondCategoryIdChanging(value);
                    this.SendPropertyChanging();
                    this._SecondCategoryId = value;
                    this.SendPropertyChanged("SecondCategoryId");
                    this.OnSecondCategoryIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SelectedCategories in the schema.
        /// </summary>
        [Column(Storage = "_SelectedCategories", DbType = "VARCHAR(50)", UpdateCheck = UpdateCheck.Never)]
        public string SelectedCategories
        {
            get
            {
                return this._SelectedCategories;
            }
            set
            {
                if (this._SelectedCategories != value)
                {
                    this.OnSelectedCategoriesChanging(value);
                    this.SendPropertyChanging();
                    this._SelectedCategories = value;
                    this.SendPropertyChanged("SelectedCategories");
                    this.OnSelectedCategoriesChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DateModified in the schema.
        /// </summary>
        [Column(Storage = "_DateModified", DbType = "DATETIME", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> DateModified
        {
            get
            {
                return this._DateModified;
            }
            set
            {
                if (this._DateModified != value)
                {
                    this.OnDateModifiedChanging(value);
                    this.SendPropertyChanging();
                    this._DateModified = value;
                    this.SendPropertyChanged("DateModified");
                    this.OnDateModifiedChanged();
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
    /// There are no comments for ChatLogContext.LogMessage in the schema.
    /// </summary>
    [Table(Name = @"dbo.LogMessages")]
    public partial class LogMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _Id;

        private string _Chatter;

        private System.Nullable<System.DateTime> _ChatTimestamp;

        private string _Message;

        private System.Nullable<short> _Status = 0;

        private string _SessionFileName;

        private System.Nullable<System.DateTime> _DateModified = DateTime.Now;

        private System.Nullable<System.DateTime> _CreatedDate = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnChatterChanging(string value);
        partial void OnChatterChanged();
        partial void OnChatTimestampChanging(System.Nullable<System.DateTime> value);
        partial void OnChatTimestampChanged();
        partial void OnMessageChanging(string value);
        partial void OnMessageChanged();
        partial void OnStatusChanging(System.Nullable<short> value);
        partial void OnStatusChanged();
        partial void OnSessionFileNameChanging(string value);
        partial void OnSessionFileNameChanged();
        partial void OnDateModifiedChanging(System.Nullable<System.DateTime> value);
        partial void OnDateModifiedChanged();
        partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCreatedDateChanged();
        #endregion

        public LogMessage()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
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
        /// There are no comments for Chatter in the schema.
        /// </summary>
        [Column(Storage = "_Chatter", DbType = "NVARCHAR(200)", UpdateCheck = UpdateCheck.Never)]
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
        /// There are no comments for ChatTimestamp in the schema.
        /// </summary>
        [Column(Storage = "_ChatTimestamp", DbType = "DATETIME", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> ChatTimestamp
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
        /// There are no comments for Message in the schema.
        /// </summary>
        [Column(Storage = "_Message", DbType = "NVARCHAR(MAX)", UpdateCheck = UpdateCheck.Never)]
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
        /// There are no comments for Status in the schema.
        /// </summary>
        [Column(Storage = "_Status", DbType = "SMALLINT", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<short> Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                if (this._Status != value)
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._Status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for SessionFileName in the schema.
        /// </summary>
        [Column(Storage = "_SessionFileName", DbType = "NVARCHAR(50)", UpdateCheck = UpdateCheck.Never)]
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
        /// There are no comments for DateModified in the schema.
        /// </summary>
        [Column(Storage = "_DateModified", DbType = "DATETIME", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> DateModified
        {
            get
            {
                return this._DateModified;
            }
            set
            {
                if (this._DateModified != value)
                {
                    this.OnDateModifiedChanging(value);
                    this.SendPropertyChanging();
                    this._DateModified = value;
                    this.SendPropertyChanged("DateModified");
                    this.OnDateModifiedChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for CreatedDate in the schema.
        /// </summary>
        [Column(Storage = "_CreatedDate", DbType = "DATETIME", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                if (this._CreatedDate != value)
                {
                    this.OnCreatedDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreatedDate = value;
                    this.SendPropertyChanged("CreatedDate");
                    this.OnCreatedDateChanged();
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
