namespace A7
{
    public class Professor:ICitizen,ITeacher
    {
        string _name;
        public string Name
        {
            set
            {
                this._name = value;
            }
            get
            {
                return this._name;
            }
        }
        string _Nationalid;
        public string NationalId
        {
            set
            {
                this._Nationalid = value;
            }
            get
            {
                return this._Nationalid;
            }
        }
        Degree _Topdegree;
        public Degree TopDegree
        {
            set
            {
                this._Topdegree = value;
            }
            get
            {
                return this._Topdegree;
            }
        }
        string _ImgUrl;
        public string ImgUrl
        {
            set
            {
                this._ImgUrl = value;
            }
            get
            {
                return this._ImgUrl;
            }
        }
        int _ResearchCount;
        public int ResearchCount
        {
            set
            {
                this._ResearchCount = value;
            }
            get
            {
                return this._ResearchCount;
            }

        }
        public Professor(string nationalId, string name, string imgUrl, Degree topDegree, int ResearchCount)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
            this.ResearchCount = ResearchCount;
        }
        public string Teach()
        {
            string teach = $"Professor {Name} is teaching";
            return teach;
        }

    }
}