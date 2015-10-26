﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI
{
        public class Answer
        {
            //public int AnswerId { get; set; }
            public string AnswerText { get; set; }
            public bool IsCorrect { get; set; }

            public Answer(string answerText, bool isCorrect)
            {
                AnswerText = answerText;
                IsCorrect = isCorrect;
            }
        }
    
}
