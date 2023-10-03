using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ComplexNumber
    {
        public double real  { get; private set; }
        public double imaginary;

        public double Imaginary { 
            get 
            { 
                return imaginary; 
            } 
            private set 
            {
                if (value == 0)
                {
                }
                else
                {
                    imaginary = value;
                }
            } 
        }

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.real = realPart;
            this.Imaginary = imaginaryPart;
        }

        /// <summary>
        /// |a| =  √(real^2 + imaginary^2)
        /// </summary>
        /// <returns>Модуль комплексного числа</returns>
        public double Abs()//absolute
        {
            return Math.Sqrt(real * real + Imaginary * Imaginary);
        }
        
        public double Argument() 
        { 
            return Math.Atan(Imaginary / real);
        }

        // a^(1/n) = |a|^(1/n) * (cos(φ+2pi*k)/n + isin(φ+2pi*k)/n)
        public ComplexNumber RootByPower(double power) {
            if (power == 0)
            {
                throw new Exception("Power = 0");
            }
            double realPart = Math.Pow(Abs(), 1 / power) * Math.Cos(Argument());
            double imaginaryPart = Math.Pow(Abs(), 1 / power) * Math.Sin(Argument());
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real + right.real, left.Imaginary + right.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real - right.real, left.Imaginary - right.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            double realPart = left.real * right.real - left.Imaginary * right.Imaginary;
            double imaginaryPart = left.real * right.Imaginary + left.Imaginary * right.real;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            double denominator = right.real * right.real + right.Imaginary * right.Imaginary;
            if (denominator == 0) {
                throw new Exception("Error");
            }
            double realPart = (left.real * right.real + left.Imaginary * right.Imaginary) / denominator;
            double imaginaryPart = (left.Imaginary * right.real - left.real * right.Imaginary) / denominator;

            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static ComplexNumber operator ++(ComplexNumber left)
        {
            return new ComplexNumber(left.real+1, left.Imaginary+1);
        }

        public override string ToString()
        {
            return Imaginary > 0 ? $"{real} + {Imaginary}i" : $"{real} - {-Imaginary}i";

        }

        
    }
}
