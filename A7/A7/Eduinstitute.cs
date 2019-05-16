using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        string _Title;
        public string Title
        {
            set
            {
                this._Title = value;
            }
            get
            {
                return this._Title;
            }
        }
        Degree _MinimumDegree;
        public Degree MinimumDegree
        {
            set
            {
                this._MinimumDegree = value;
            }
            get
            {
                return this._MinimumDegree;
            }
        }
        List<TTeacher> _TTeacher;
        public List<TTeacher> Teachers
        {
            set
            {
                this._TTeacher = value;
            }
            get
            {
                return this._TTeacher;
            }

        } 
        public EduInstitute(string title, Degree minimumDegree, List<TTeacher> teachers=null)
        {
            Title = title;
            MinimumDegree = minimumDegree;
            Teachers = teachers;
        }
       

        public bool IsEligible(TTeacher teacher)
        {

            if (teacher.TopDegree < this.MinimumDegree)
                return false;
            return true;
        }
        public bool Register(TTeacher teacher)
        {
            if (IsEligible(teacher) == true)
            {
                Teachers.Add(teacher);
                return true;
            }
            return false;
        }
    }
}