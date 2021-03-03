﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR.EmployeeContext.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HR.EmployeeContext.Resource.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ثبت ورود خروج در روز تعطیل امکان پذیر نمی باشد.
        /// </summary>
        public static string CanNotAssginIOInOffDate {
            get {
                return ResourceManager.GetString("CanNotAssginIOInOffDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ اتمام قرارداد نباید کوچکتر از زمان شروع قرارداد باشد.
        /// </summary>
        public static string ContractEndDateCouldNotBeLessThanStartDateException {
            get {
                return ResourceManager.GetString("ContractEndDateCouldNotBeLessThanStartDateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to شماره پرسنلی قرارداد نباید خالی باشد.
        /// </summary>
        public static string ContractsEmployeeIdNullException {
            get {
                return ResourceManager.GetString("ContractsEmployeeIdNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ شروع قرارداد باید بزگتز از تارخ شروع باشد.
        /// </summary>
        public static string ContractsStartDateMustBiggerThanLastContractEndDateException {
            get {
                return ResourceManager.GetString("ContractsStartDateMustBiggerThanLastContractEndDateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ پایان قرارداد با قرارداد های قبلی تداخل دارد.
        /// </summary>
        public static string EmployeeEndDateOfContractConflictedWithOtherContracts {
            get {
                return ResourceManager.GetString("EmployeeEndDateOfContractConflictedWithOtherContracts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کارمندی با این کد پرسنلی وجود ندارد.
        /// </summary>
        public static string EmployeeIdOfContractIsNotExist {
            get {
                return ResourceManager.GetString("EmployeeIdOfContractIsNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ قرارداد مغایرت دارد.
        /// </summary>
        public static string EmployeeStartAndEndDateOfContractConflictedWithOtherContracts {
            get {
                return ResourceManager.GetString("EmployeeStartAndEndDateOfContractConflictedWithOtherContracts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ شروع قرارداد با قرارداد های قبلی تداخل دارد .
        /// </summary>
        public static string EmployeeStartDateOfContractConflictedWithOtherContracts {
            get {
                return ResourceManager.GetString("EmployeeStartDateOfContractConflictedWithOtherContracts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ساعات وارد شده در بازه شیفت نمی باشد.
        /// </summary>
        public static string EnteredTimeIsNotInSegmentInside {
            get {
                return ResourceManager.GetString("EnteredTimeIsNotInSegmentInside", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام اجباری است.
        /// </summary>
        public static string FirstNameIsRequiredException {
            get {
                return ResourceManager.GetString("FirstNameIsRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ایندکس وارد شده خارج از بازه تعدادی ایندکس ها می باشد..
        /// </summary>
        public static string IndexISOutOfRangeException {
            get {
                return ResourceManager.GetString("IndexISOutOfRangeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کارمندی با این مشخصات برای ثبت ورود خروج وجود ندارد.
        /// </summary>
        public static string IOEmployeeIdNullException {
            get {
                return ResourceManager.GetString("IOEmployeeIdNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام خانوادگی اجباری است.
        /// </summary>
        public static string LastNameIsRequiredException {
            get {
                return ResourceManager.GetString("LastNameIsRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to فرمت کد ملی صحیح نیست.
        /// </summary>
        public static string NationalCodeCheckSumIsNotValidException {
            get {
                return ResourceManager.GetString("NationalCodeCheckSumIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد ملی اجاری است.
        /// </summary>
        public static string NationalCodeIsRequiredException {
            get {
                return ResourceManager.GetString("NationalCodeIsRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد ملی باید 10 رقم باشد.
        /// </summary>
        public static string NationalCodeLengthIsNotValidException {
            get {
                return ResourceManager.GetString("NationalCodeLengthIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد ملی باید عددی باشد.
        /// </summary>
        public static string NationalCodeMustBeDigitException {
            get {
                return ResourceManager.GetString("NationalCodeMustBeDigitException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد ملی نباید تکراری باشد.
        /// </summary>
        public static string NationalCodeMustBeUniqueException {
            get {
                return ResourceManager.GetString("NationalCodeMustBeUniqueException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی اجباری می باشد.
        /// </summary>
        public static string PersonalCodeIsRequiredException {
            get {
                return ResourceManager.GetString("PersonalCodeIsRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی باید عددی باشد.
        /// </summary>
        public static string PersonalCodeMustBeDigitException {
            get {
                return ResourceManager.GetString("PersonalCodeMustBeDigitException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ انتساب شیفت معتبر نمی باشد.
        /// </summary>
        public static string ShiftSegmentStartDateIsNotValid {
            get {
                return ResourceManager.GetString("ShiftSegmentStartDateIsNotValid", resourceCulture);
            }
        }
    }
}