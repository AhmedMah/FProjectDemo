using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelenceProjectDemo.Models
{
    public class CoordinatorTrainingCourseDetail
    {
        public int CoordinatorTrainingCourseDetailId { get; set; }

        public int CoordinatorTrainingCourseId { get; set; }
        public CoordinatorTrainingCourse CoordinatorTrainingCourse { get; set; }

        public string Achievements { get; set; }
        public string Constraints { get; set; }
        public string Notes { get; set; }

        public bool Status { get; set; }
        public string TrainerParticipating { get; set; }
        public string attachment { get; set; }

    }
}
