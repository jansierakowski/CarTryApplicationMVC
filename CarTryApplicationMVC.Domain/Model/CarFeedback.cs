using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarFeedback
    {
        public int Id { get; set; }
        public string FeedbackDetial { get; set; }
        public DateTime WhenOpinionsWasAdded { get; set; }
        public int CarId { get; set; }
        public virtual CarSpecification CarSpecifications { get; set; }
    }
}
