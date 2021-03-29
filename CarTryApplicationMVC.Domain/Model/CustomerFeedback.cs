using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CustomerFeedback
    {
        public int Id { get; set; }
        public string FeedbackDetial { get; set; }
        public DateTime WhenOpinionsWasAdded { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
