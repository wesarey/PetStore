namespace PetStore
{
    public class DogLeash : Product
    {
        public string Material { get; set; }
        public int LengthInches { get; set; }
        public override string DisplayName
        {
            get
            {
                return $"{Name} - {Material} - {LengthInches} inches";
            }
        }
    }
}
