using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Make: {Make}");
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"HorsePower: {HorsePower}");
            stringBuilder.AppendLine($"RegistrationNumber: {RegistrationNumber}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
