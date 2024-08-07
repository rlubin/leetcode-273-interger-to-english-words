public class Solution { 
    public string NumberToWords(int num) {
        //up to 2147483647
        //all tens placements; up to billions
        NumberWord zero = new (0, "Zero");

        if (num == 0) {
            return zero.word;
        }

        List<NumberWord> ones = [ new (0, ""), new (1, "One"), new (2, "Two"), new (3, "Three"), new (4, "Four"), new (5, "Five"), new (6, "Six"), new (7, "Seven"), new (8, "Eight"), new (9, "Nine") ];

        List<NumberWord> tens1019 = [ new (10, "Ten"),new (11, "Eleven"), new (12, "Twelve"), new (13, "Thirteen"), new (14, "Fourteen"), new (15, "Fifteen"), new (16, "Sixteen"), new (17, "Seventeen"), new (18, "Eighteen"), new (19, "Nineteen") ];

        List<NumberWord> tens2090 = [ new (0, ""), new (2, "Twenty"), new (3, "Thirty"), new (4, "Forty"), new (5, "Fifty"), new (6, "Sixty"), new (7, "Seventy"), new (8, "Eighty"), new (9, "Ninety") ];

        string strNumber = num.ToString();
        int length = strNumber.Length;
        string writtenNumber = "";
        int previousNumber = -1;

        for (int i = 0; i < length; i++) {
            int currentNumber = Int32.Parse(strNumber.Substring(i, 1));
            // Console.Write(strNumber.Substring(i, 1));

            //figure out number placement
            // string placeValue = GetPlaceValue(length, i);
            // Console.Write($" {placeValue}\n");

            int difference = length - i;
            
            string word = "";
            //ones
            if (difference == 1) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += $" {word}";
            }
            //tens
            else if (difference == 2) {
                //check to see if between 10-19, special case
                if (currentNumber == 1) {
                    int tens = Int32.Parse(strNumber.Substring(i, 2));
                    // Console.WriteLine($"10-19 {tens}");
                    word = tens1019.Find(x => x.number == tens).word;
                    writtenNumber += $" {word} ";
                    i++;
                } else {
                    word = tens2090.Find(x => x.number == currentNumber).word;
                    writtenNumber += $" {word} ";
                }
            }
            //hundreds
            else if (difference == 3) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += currentNumber == 0 ? $" {word} " : $" {word} Hundred ";
            }
            //one thousands
            else if (difference == 4) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += currentNumber == 0 ? $" {word} " : $" {word} Thousand ";
            }
            //ten thousands
            else if (difference == 5) {
                //check to see if between 10-19, special case
                if (currentNumber == 1) {
                    int tens = Int32.Parse(strNumber.Substring(i, 2));
                    // Console.WriteLine($"10-19 {tens}\n");
                    word = tens1019.Find(x => x.number == tens).word;
                    writtenNumber += $" {word} Thousand ";
                    i++;
                } else {
                    word = tens2090.Find(x => x.number == currentNumber).word;
                    int nextNumber = Int32.Parse(strNumber.Substring(i + 1, 1));
                    if (currentNumber != 0 && nextNumber == 0 ) {
                        writtenNumber += $" {word} Thousand ";
                        i++;
                    }
                    else if (currentNumber == 0 && nextNumber == 0 && (previousNumber > 0)) {
                        writtenNumber += $" {word} Thousand ";
                        i++;
                    } else if (currentNumber == 0 && nextNumber == 0 && (previousNumber == -1 || previousNumber == 0)) {
                        writtenNumber += $" {word} ";
                        i++;
                    } else {
                        writtenNumber += $" {word} ";
                    }
                }
            }
            //hundred thousands
            else if (difference == 6) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += currentNumber == 0 ? $" {word} " : $" {word} Hundred ";
            }
            //millions
            else if (difference == 7) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += $" {word} Million ";
            }
            //ten millions
            else if (difference == 8) {
                //check to see if between 10-19, special case
                if (currentNumber == 1) {
                    int tens = Int32.Parse(strNumber.Substring(i, 2));
                    // Console.WriteLine($"10-19 {tens}\n");
                    word = tens1019.Find(x => x.number == tens).word;
                    writtenNumber += $" {word} Million ";
                    i++;
                } else {
                    word = tens2090.Find(x => x.number == currentNumber).word;
                    int nextNumber = Int32.Parse(strNumber.Substring(i + 1, 1));
                    if (currentNumber != 0 && nextNumber == 0 ) {
                        writtenNumber += $" {word} Million ";
                        i++;
                    }
                    else if (currentNumber == 0 && nextNumber == 0 && (previousNumber > 0)) {
                        writtenNumber += $" {word} Million ";
                        i++;
                    } else if (currentNumber == 0 && nextNumber == 0 && (previousNumber == -1 || previousNumber == 0)) {
                        writtenNumber += $" {word} ";
                        i++;
                    } else {
                        writtenNumber += $" {word} ";
                    }
                }
            }
            //hundred millions
            else if (difference == 9) {
                word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += currentNumber == 0 ? $" {word} " : $" {word} Hundred ";
            }
             //billions
            else if (difference == 10) {
                    word = ones.Find(x => x.number == currentNumber).word;
                writtenNumber += $" {word} Billion ";
            }

            previousNumber = currentNumber;
        }
        
        //make sure there is only 1 space between each word
        //trim to remove excess spaces at the end
        return writtenNumber.Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Trim();;
    }

    // public string GetPlaceValue(int length, int index) {
    //     List<NumberWord> placeValue = [ new (1, "ones"), new (2, "tens"), new (3, "hundreds"), new (4, "thousands"), new (5, "tenThousands"), new (6, "hundredThousands"), new (7, "millions"), new (8, "tenMillions"), new (9, "hundredMillions"), new (10, "billions") ];

    //     int difference = length - index;

    //     return placeValue.Find(x => x.number == difference).word;
    // }
}

public class NumberWord {
    public int number;
    public string word;

    public NumberWord(int num, string str) {
        number = num;
        word = str;
    }
}
