using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWA_Quiz.Models
{
    public class QuizViewModel
    {
        //public int Id { get; set; }

        [DisplayName("Question")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string Title { get; set; }

        [DisplayName("Further description")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string Description { get; set; }
        

        public int NumberOfCorrectAnswers { get; set; }

        public List<Answer> answerList;

        [DisplayName("Answer")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}