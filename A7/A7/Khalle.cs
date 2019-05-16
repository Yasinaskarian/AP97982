namespace A7
{
    public class Khalle : ICitizen, ITeacher
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
        public string NationalId {
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
       
        
        public Degree TopDegree {
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
        public string ImgUrl {
            set
            {
                this._ImgUrl = value;
            }
            get
            {
                return this._ImgUrl;
            }
        }
        public Khalle(string nationalId,string name, string imgUrl , Degree topDegree)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
        }
        public string Teach()
        {
            string teach = $"Khalle {Name} is teaching"; 
            return teach;
        }
    }
}