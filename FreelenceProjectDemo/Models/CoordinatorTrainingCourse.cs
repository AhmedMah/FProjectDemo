using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelenceProjectDemo.Models
{
    public class CoordinatorTrainingCourse
    {
        public int CoordinatorTrainingCourseId { get; set; }

        public DateTime AssignmentDate { get; set; }

        public int MajorId { get; set; }
        public virtual Major Major { get; set; }


        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        public string TrainerName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ReportTypeId { get; set; }
        public virtual ReportType ReportType { get; set; }

        public DateTime DeadlineDate { get; set; }



    }
}
