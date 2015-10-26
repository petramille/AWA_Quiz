using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BI;

namespace AWA_Quiz.Models
{
    public class QuizViewModel
    {
        //Properties related to the quiz
        [DisplayName("Title")]
        [Required]
        [MaxLength(50, ErrorMessage = "The title is too long")]
        public string QuizTitle { get; set; }

        [DisplayName("Description")]
        public string QuizDescription { get; set; }

        [DisplayName("Category")]
        public string QuizCategory { get; set; }



        [DisplayName("Question")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string QuestionTitle { get; set; }

        [DisplayName("Further description")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        //[RegularExpression(@"^[a-zA-Z0-9u+2423]{2,20}$", ErrorMessage = "")]
        public string QuestionDescription { get; set; }
        

        public int NumberOfCorrectAnswers { get; set; }

        public List<Answer> answerList;

        [DisplayName("Answer")]
        [Required]
        [DataTypeAttribute(DataType.MultilineText)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}