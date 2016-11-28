using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotations.Components;
using DataAnnotations.Resources;

namespace DataAnnotations.ViewModels.Memo
{
    [CustomValidation(typeof(MemoDocument), "ValidateMemo")]
    public class MemoDocument : ViewModelBase
    {
        public MemoDocument()
        {
            Created = DateTime.Now;
            //DueBy = Created;
            Category = Categories.Work;
        }

        [Required(ErrorMessage = "A description is required.")]
        [StringLength(50)]
        public String Text { get; set; }

        [Required(ErrorMessageResourceName = "MustSetPriority", ErrorMessageResourceType = typeof(Strings))]
        [Range(1, 5, ErrorMessageResourceName = "InvalidPriority", ErrorMessageResourceType = typeof(Strings))]
        public Int32 Priority { get; set; }

        public Decimal Price { get; set; }

        [Required]
        public DateTime Created { get; set; }

        //[Compare("Created")]
        //[GreaterThanDate("Created")]
        //public DateTime? DueBy { get; set; }

        [Required]
        public Categories Category { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Empty or an email address ")]
        public String RelatedEmail { get; set; }

        [Remote("CheckCustomer", "Memo", AdditionalFields = "Text, MagicNumber", ErrorMessage = "Not an existing customer")]
        [DisplayName("Related Customer")]
        public String RelatedCustomer { get; set; }

        #region Custom attributes
        [ClientEvenNumber(MultipleOf4 = true)]
        public Int32 MagicNumber { get; set; }
        #endregion

        #region Embedded validators
        public static ValidationResult ValidateMemo(MemoDocument memo, ValidationContext context)
        {
            // context is NOT used here but context.ObjectType contains a reference to the class that hosts the 
            // value being validated. Can only access properties via reflection.
            if (memo.Category == Categories.Personal && memo.Priority > 3)
                return new ValidationResult("Category and priority are not consistent.");

            return ValidationResult.Success;
        }
        #endregion
    }
}
