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
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }


    }
}
