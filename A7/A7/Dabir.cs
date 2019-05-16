namespace A7
{
    public class Dabir: ICitizen,ITeacher
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
        int _Under100StudentCount;
        public int Under100StudentCount
        {
            set
            {
                this._Under100StudentCount = value;
            }
            get
            {
                return this._Under100StudentCount;
            }

        }
        public Dabir(string nationalId, string name, string imgUrl, Degree topDegree,int under100StudentCount)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
            Under100StudentCount = under100StudentCount;
        }
        public string Teach()
        {
            string teach = $"Dabir {Name} is teaching";
            return teach;
        }
    }
}