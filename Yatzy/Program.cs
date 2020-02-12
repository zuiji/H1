using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Markup;

namespace Yatzy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    internal class Dice
    {
        public Dice(int numberOfSides)
        {
            Reset();
            NumberOfSides = numberOfSides;
        }
        public int NumberOfSides { get; set; }

        public int Value { get; private set; }

        public bool IsLocked { get; private set; }

        public int RollDice()
        {
            var random = new Random();
            //todo Check if max value is correct or one to low
            Value = random.Next(1, NumberOfSides);
            return Value;
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Reset()
        {
            NumberOfSides = 0;
            Value = 0;
            IsLocked = false;
        }
    }

    internal class DiceCup
    {
        private List<Dice> _dices = new List<Dice>();

        public DiceCup(int numberOfDices)
        {
            for (int i = 0; i < numberOfDices; i++)
            {
                _dices.Add(new Dice(6));
            }
        }

        public List<Dice> RoleAllDices()
        {
            foreach (Dice dice in _dices)
            {
                dice.RollDice();
            }
            return _dices;
        }
    }

    internal class ScoreBoard
    {
        private List<Row> _rows = new List<Row>();


        private List<Row> ListOfRows()
        {
            return ListOfRows();
        }

        public int Score()
        {
            return ListOfRows().Sum(i => i.Score);
        }
    }

    internal class Player
    {
        public string Name { get; set; }

        public bool IsAi { get; set; }
    }

    internal abstract class Row
    {
        public int Score { get; set; }

        public abstract bool IsValidMove(List<Dice> dices);

        public bool doMove(List<Dice> dices)
        {
            if (IsValidMove(dices))
            {
                Score = moveScore(dices);
                return true;
            }
            else
            {
                return false;
            }

        }

        public abstract int moveScore(List<Dice> dices);

        public int minNumberOfDices { get; private set; }
    }

    class oneSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 1);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 1).Sum(i => i.Value);
        }
    }

    class twoSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 2);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 2).Sum(i => i.Value);
        }
    }

    class treeSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 3);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 3).Sum(i => i.Value);
        }
    }

    class fourSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 4);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 4).Sum(i => i.Value);
        }
    }


    class fifthSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 5);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 5).Sum(i => i.Value);
        }
    }


    class sixthSRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            return dices.Any(i => i.Value == 6);
        }

        public override int moveScore(List<Dice> dices)
        {
            return dices.Where(i => i.Value == 6).Sum(i => i.Value);
        }
    }

    class OnePairRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            List<int> values = new List<int>();
            List<int> pairs = new List<int>();
            foreach (Dice dice in dices)
            {
                if (values.Contains(dice.Value))
                {
                    pairs.Add(dice.Value);
                    values.Remove(dice.Value);
                }
                else
                {
                    values.Add(dice.Value);
                }
            }

            return pairs.Any();
        }

        public override int moveScore(List<Dice> dices)
        {
            List<int> values = new List<int>();
            List<int> pairs = new List<int>();
            foreach (Dice dice in dices)
            {
                if (values.Contains(dice.Value))
                {
                    pairs.Add(dice.Value);
                    values.Remove(dice.Value);
                }
                else
                {
                    values.Add(dice.Value);
                }
            }

            return pairs.Max() * 2;
        }
    }

    class twoPairsRow : Row
    {
        public override bool IsValidMove(List<Dice> dices)
        {
            List<int> values = new List<int>();
            List<int> pairs = new List<int>();
            foreach (Dice dice in dices)
            {
                if (values.Contains(dice.Value))
                {
                    pairs.Add(dice.Value);
                    values.Remove(dice.Value);
                }
                else
                {
                    values.Add(dice.Value);
                }
            }

            return pairs.Count > 2;
        }

        public override int moveScore(List<Dice> dices)
        {
            List<int> values = new List<int>();
            List<int> pairs = new List<int>();
            foreach (Dice dice in dices)
            {
                if (values.Contains(dice.Value))
                {
                    pairs.Add(dice.Value);
                    values.Remove(dice.Value);
                }
                else
                {
                    values.Add(dice.Value);
                }
            }

            var returnvalue = pairs.Max() * 2;
            pairs.Remove(pairs.Max());
            returnvalue += pairs.Max() * 2;
            return returnvalue;
        }
    }

    internal class controller
    {
        DiceCup diceCup = new DiceCup(5);
    }
}