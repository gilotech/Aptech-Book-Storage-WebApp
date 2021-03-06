﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 14-06-2012 19:21:04
namespace aptechModel
{
    
    /// <summary>
    /// There are no comments for aptechEntities in the schema.
    /// </summary>
    public partial class aptechEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new aptechEntities object using the connection string found in the 'aptechEntities' section of the application configuration file.
        /// </summary>
        public aptechEntities() : 
                base("name=aptechEntities", "aptechEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new aptechEntities object.
        /// </summary>
        public aptechEntities(string connectionString) : 
                base(connectionString, "aptechEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new aptechEntities object.
        /// </summary>
        public aptechEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "aptechEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for book_master in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<book_master> book_master
        {
            get
            {
                if ((this._book_master == null))
                {
                    this._book_master = base.CreateQuery<book_master>("[book_master]");
                }
                return this._book_master;
            }
        }
        private global::System.Data.Objects.ObjectQuery<book_master> _book_master;
        /// <summary>
        /// There are no comments for course_master in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<course_master> course_master
        {
            get
            {
                if ((this._course_master == null))
                {
                    this._course_master = base.CreateQuery<course_master>("[course_master]");
                }
                return this._course_master;
            }
        }
        private global::System.Data.Objects.ObjectQuery<course_master> _course_master;
        /// <summary>
        /// There are no comments for module_master in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<module_master> module_master
        {
            get
            {
                if ((this._module_master == null))
                {
                    this._module_master = base.CreateQuery<module_master>("[module_master]");
                }
                return this._module_master;
            }
        }
        private global::System.Data.Objects.ObjectQuery<module_master> _module_master;
        /// <summary>
        /// There are no comments for student_master in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<student_master> student_master
        {
            get
            {
                if ((this._student_master == null))
                {
                    this._student_master = base.CreateQuery<student_master>("[student_master]");
                }
                return this._student_master;
            }
        }
        private global::System.Data.Objects.ObjectQuery<student_master> _student_master;
        /// <summary>
        /// There are no comments for book_master in the schema.
        /// </summary>
        public void AddTobook_master(book_master book_master)
        {
            base.AddObject("book_master", book_master);
        }
        /// <summary>
        /// There are no comments for course_master in the schema.
        /// </summary>
        public void AddTocourse_master(course_master course_master)
        {
            base.AddObject("course_master", course_master);
        }
        /// <summary>
        /// There are no comments for module_master in the schema.
        /// </summary>
        public void AddTomodule_master(module_master module_master)
        {
            base.AddObject("module_master", module_master);
        }
        /// <summary>
        /// There are no comments for student_master in the schema.
        /// </summary>
        public void AddTostudent_master(student_master student_master)
        {
            base.AddObject("student_master", student_master);
        }
    }
    /// <summary>
    /// There are no comments for aptechModel.book_master in the schema.
    /// </summary>
    /// <KeyProperties>
    /// bcode
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="aptechModel", Name="book_master")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class book_master : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new book_master object.
        /// </summary>
        /// <param name="bcode">Initial value of bcode.</param>
        public static book_master Createbook_master(string bcode)
        {
            book_master book_master = new book_master();
            book_master.bcode = bcode;
            return book_master;
        }
        /// <summary>
        /// There are no comments for Property bcode in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string bcode
        {
            get
            {
                return this._bcode;
            }
            set
            {
                this.OnbcodeChanging(value);
                this.ReportPropertyChanging("bcode");
                this._bcode = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("bcode");
                this.OnbcodeChanged();
            }
        }
        private string _bcode;
        partial void OnbcodeChanging(string value);
        partial void OnbcodeChanged();
        /// <summary>
        /// There are no comments for Property title in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string title
        {
            get
            {
                return this._title;
            }
            set
            {
                this.OntitleChanging(value);
                this.ReportPropertyChanging("title");
                this._title = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("title");
                this.OntitleChanged();
            }
        }
        private string _title;
        partial void OntitleChanging(string value);
        partial void OntitleChanged();
        /// <summary>
        /// There are no comments for Property qty in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> qty
        {
            get
            {
                return this._qty;
            }
            set
            {
                this.OnqtyChanging(value);
                this.ReportPropertyChanging("qty");
                this._qty = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("qty");
                this.OnqtyChanged();
            }
        }
        private global::System.Nullable<int> _qty;
        partial void OnqtyChanging(global::System.Nullable<int> value);
        partial void OnqtyChanged();
        /// <summary>
        /// There are no comments for Property ROL in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> ROL
        {
            get
            {
                return this._ROL;
            }
            set
            {
                this.OnROLChanging(value);
                this.ReportPropertyChanging("ROL");
                this._ROL = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ROL");
                this.OnROLChanged();
            }
        }
        private global::System.Nullable<int> _ROL;
        partial void OnROLChanging(global::System.Nullable<int> value);
        partial void OnROLChanged();
    }
    /// <summary>
    /// There are no comments for aptechModel.course_master in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ccode
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="aptechModel", Name="course_master")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class course_master : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new course_master object.
        /// </summary>
        /// <param name="ccode">Initial value of ccode.</param>
        public static course_master Createcourse_master(string ccode)
        {
            course_master course_master = new course_master();
            course_master.ccode = ccode;
            return course_master;
        }
        /// <summary>
        /// There are no comments for Property ccode in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ccode
        {
            get
            {
                return this._ccode;
            }
            set
            {
                this.OnccodeChanging(value);
                this.ReportPropertyChanging("ccode");
                this._ccode = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("ccode");
                this.OnccodeChanged();
            }
        }
        private string _ccode;
        partial void OnccodeChanging(string value);
        partial void OnccodeChanged();
        /// <summary>
        /// There are no comments for Property cname in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string cname
        {
            get
            {
                return this._cname;
            }
            set
            {
                this.OncnameChanging(value);
                this.ReportPropertyChanging("cname");
                this._cname = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cname");
                this.OncnameChanged();
            }
        }
        private string _cname;
        partial void OncnameChanging(string value);
        partial void OncnameChanged();
        /// <summary>
        /// There are no comments for Property startdate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> startdate
        {
            get
            {
                return this._startdate;
            }
            set
            {
                this.OnstartdateChanging(value);
                this.ReportPropertyChanging("startdate");
                this._startdate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("startdate");
                this.OnstartdateChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _startdate;
        partial void OnstartdateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnstartdateChanged();
        /// <summary>
        /// There are no comments for Property duration in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> duration
        {
            get
            {
                return this._duration;
            }
            set
            {
                this.OndurationChanging(value);
                this.ReportPropertyChanging("duration");
                this._duration = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("duration");
                this.OndurationChanged();
            }
        }
        private global::System.Nullable<int> _duration;
        partial void OndurationChanging(global::System.Nullable<int> value);
        partial void OndurationChanged();
    }
    /// <summary>
    /// There are no comments for aptechModel.module_master in the schema.
    /// </summary>
    /// <KeyProperties>
    /// mcode
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="aptechModel", Name="module_master")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class module_master : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new module_master object.
        /// </summary>
        /// <param name="mcode">Initial value of mcode.</param>
        public static module_master Createmodule_master(string mcode)
        {
            module_master module_master = new module_master();
            module_master.mcode = mcode;
            return module_master;
        }
        /// <summary>
        /// There are no comments for Property mcode in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string mcode
        {
            get
            {
                return this._mcode;
            }
            set
            {
                this.OnmcodeChanging(value);
                this.ReportPropertyChanging("mcode");
                this._mcode = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("mcode");
                this.OnmcodeChanged();
            }
        }
        private string _mcode;
        partial void OnmcodeChanging(string value);
        partial void OnmcodeChanged();
        /// <summary>
        /// There are no comments for Property mname in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string mname
        {
            get
            {
                return this._mname;
            }
            set
            {
                this.OnmnameChanging(value);
                this.ReportPropertyChanging("mname");
                this._mname = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("mname");
                this.OnmnameChanged();
            }
        }
        private string _mname;
        partial void OnmnameChanging(string value);
        partial void OnmnameChanged();
        /// <summary>
        /// There are no comments for Property comment in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                this.OncommentChanging(value);
                this.ReportPropertyChanging("comment");
                this._comment = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("comment");
                this.OncommentChanged();
            }
        }
        private string _comment;
        partial void OncommentChanging(string value);
        partial void OncommentChanged();
    }
    /// <summary>
    /// There are no comments for aptechModel.student_master in the schema.
    /// </summary>
    /// <KeyProperties>
    /// scode
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="aptechModel", Name="student_master")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class student_master : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new student_master object.
        /// </summary>
        /// <param name="scode">Initial value of scode.</param>
        public static student_master Createstudent_master(int scode)
        {
            student_master student_master = new student_master();
            student_master.scode = scode;
            return student_master;
        }
        /// <summary>
        /// There are no comments for Property scode in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int scode
        {
            get
            {
                return this._scode;
            }
            set
            {
                this.OnscodeChanging(value);
                this.ReportPropertyChanging("scode");
                this._scode = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("scode");
                this.OnscodeChanged();
            }
        }
        private int _scode;
        partial void OnscodeChanging(int value);
        partial void OnscodeChanged();
        /// <summary>
        /// There are no comments for Property sname in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string sname
        {
            get
            {
                return this._sname;
            }
            set
            {
                this.OnsnameChanging(value);
                this.ReportPropertyChanging("sname");
                this._sname = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("sname");
                this.OnsnameChanged();
            }
        }
        private string _sname;
        partial void OnsnameChanging(string value);
        partial void OnsnameChanged();
        /// <summary>
        /// There are no comments for Property contact in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> contact
        {
            get
            {
                return this._contact;
            }
            set
            {
                this.OncontactChanging(value);
                this.ReportPropertyChanging("contact");
                this._contact = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("contact");
                this.OncontactChanged();
            }
        }
        private global::System.Nullable<long> _contact;
        partial void OncontactChanging(global::System.Nullable<long> value);
        partial void OncontactChanged();
        /// <summary>
        /// There are no comments for Property password in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string password
        {
            get
            {
                return this._password;
            }
            set
            {
                this.OnpasswordChanging(value);
                this.ReportPropertyChanging("password");
                this._password = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("password");
                this.OnpasswordChanged();
            }
        }
        private string _password;
        partial void OnpasswordChanging(string value);
        partial void OnpasswordChanged();
        /// <summary>
        /// There are no comments for Property invoiceno in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> invoiceno
        {
            get
            {
                return this._invoiceno;
            }
            set
            {
                this.OninvoicenoChanging(value);
                this.ReportPropertyChanging("invoiceno");
                this._invoiceno = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("invoiceno");
                this.OninvoicenoChanged();
            }
        }
        private global::System.Nullable<int> _invoiceno;
        partial void OninvoicenoChanging(global::System.Nullable<int> value);
        partial void OninvoicenoChanged();
    }
}
