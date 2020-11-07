using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace QECalculator.Pages.QECalculator
{
    public class QECalculatorViewModel : INotifyPropertyChanged
    {
        public QECalculatorViewModel() {
            OnClearBtnClicked = new Command(() => {
                A = "0";
                B = "0";
                C = "0";
            });
            OnCalculateBtnClicked = new Command(() => {
                if (float.TryParse(a, out float aFloat) && 
                    float.TryParse(b, out float bFloat) &&
                    float.TryParse(c, out float cFloat))
                {
                    try
                    {
                        var equationResult = QuadraticEquation.Calculate(aFloat, bFloat, cFloat);
                        if (equationResult.RootsAmount == 0)
                        {
                            Result = "Quadratic equation does not have Real solution";
                        }
                        else if (equationResult.RootsAmount == 1)
                        {
                            Result = $"Quadratic equation have one Real root equal {equationResult.X1}";
                        }
                        else
                        {
                            Result = $"Quadratic equation have two Real roots equal {equationResult.X1} and {equationResult.X2}";
                        }
                    }
                    catch (QuadraticEquationException qeException)
                    {
                        Result = qeException.Message;
                    }
                }
                else
                {
                    Result = "Cannot calculate, please ensure that all values are valid.";
                }
            });
        }

        private string a = "0";
        private string b = "0";
        private string c = "0";
        public string A {
            get { return a; }
            set {
                    a = value;
                    OnPropertyChanged(nameof(A));
                    ShowValidationResults();
            }
        }
        public string B { 
            get { return b; }
            set {
                b = value;
                OnPropertyChanged(nameof(B));
                ShowValidationResults();
            }
        }
        public string C { 
            get { return c; } 
            set {
                c = value;
                OnPropertyChanged(nameof(C));
                ShowValidationResults();
            }
        }
        private string result = "Result";
        public string Result {
            get { return result; }
            set { 
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public Command OnClearBtnClicked { get; }
        public Command OnCalculateBtnClicked { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));       
        }

        private void ShowValidationResults()
        {
            bool aIsValid = float.TryParse(a, out _);
            bool bIsValid = float.TryParse(b, out _);
            bool cIsValid = float.TryParse(c, out _);

            StringBuilder validationResultMessage = new StringBuilder();
            if (!aIsValid) {
                validationResultMessage.AppendLine("Value of a is not valid");
            }
            if (!bIsValid)
            {
                validationResultMessage.AppendLine("Value of b is not valid");
            }
            if (!cIsValid)
            {
                validationResultMessage.AppendLine("Value of c is not valid");
            }
            Result = validationResultMessage.ToString();
        }
    }
}
