using System;
using System.Linq;
class Piece
{
    public string Colour;
    public int Number;
    public int numberwise_count;
    public int colourwise_count;

    public Piece(string Colour, int Number, int numberwise_count, int colourwise_count)
    {
        this.Colour = Colour;
        this.Number = Number;
        this.numberwise_count = numberwise_count;
        this.colourwise_count = colourwise_count;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Piece[] pieces = new Piece[106];        //Creating pieces
        Piece[] hand = new Piece[21];
        Piece[] organized_hand = new Piece[21];
        Random rnd = new Random();

        for (int i = 0; i < 13; i++)
            pieces[i] = new Piece("Blue", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 13] = new Piece("Blue", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 26] = new Piece("Red", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 39] = new Piece("Red", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 52] = new Piece("Black", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 65] = new Piece("Black", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 78] = new Piece("Yellow", i + 1, 0, 0);

        for (int i = 0; i < 13; i++)
            pieces[i + 91] = new Piece("Yellow", i + 1, 0, 0);

        pieces[104] = new Piece("S", 0, 0, 0);
        pieces[105] = new Piece("S", 0, 0, 0);

        Piece okey = new Piece("Yellow", 12, 0, 0); ;

        int okey_selection = rnd.Next(104);         //Selecting Okey piece

        if (pieces[okey_selection].Number == 13)
        {
            Console.WriteLine("Okey : " + pieces[okey_selection].Colour + " " + 1);
            okey = new Piece(pieces[okey_selection].Colour, 1, 0, 0);
        }
        else
        {
            Console.WriteLine("Okey : " + pieces[okey_selection].Colour + " " + (pieces[okey_selection].Number + 1));
            okey = new Piece(pieces[okey_selection].Colour, pieces[okey_selection].Number + 1, 0, 0);
        }

        int[] dealt_pieces = new int[21];       //Dealing hand
        int counter = 0;
        while (counter < 21)
        {
            int dealt_piece = rnd.Next(106);

            if ((!dealt_pieces.Contains(dealt_piece)) && dealt_piece != okey_selection)
            {
                hand[counter] = pieces[dealt_piece];
                dealt_pieces[counter] = dealt_piece;
                counter++;
            }
        }

        for (int i = 0; i < 21; i++)
            if (hand[i].Colour == okey.Colour && hand[i].Number == okey.Number)
            {
                hand[i].Colour = "OKEY";
                hand[i].Number = 0;
            }

        for (int i = 0; i < 21; i++)
            if (hand[i].Colour == "S")
            {
                hand[i].Colour = okey.Colour;
                hand[i].Number = okey.Number;
            }

        hand = hand.OrderBy(c => c.Number).ToArray();

        Console.WriteLine("Dealt Hand: ");
        for (int i = 0; i < 21; i++)
            Console.WriteLine(hand[i].Colour + " " + hand[i].Number);

        if (hand[0].Number != 0)        //Arranging hand
            organized_hand = Arrange(hand);

        else if (hand[0].Number == 0 && hand[1].Number != 0)
        {
            int max_sum = 0;
            Piece best_okey = new Piece(hand[0].Colour, hand[0].Number, 0, 0);

            //trying blue
            for (int i = 1; i < 14; i++)
            {
                Piece[] temp_hand = hand;
                temp_hand[0].Colour = "Blue";
                temp_hand[0].Number = i;
                Piece temp_best_okey = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                temp_hand = Arrange(temp_hand);
                if (max_sum < get_Sum(temp_hand))
                {
                    max_sum = get_Sum(temp_hand);
                    best_okey.Colour = temp_best_okey.Colour;
                    best_okey.Number = temp_best_okey.Number;
                }
            }

            //trying red
            for (int i = 1; i < 14; i++)
            {
                Piece[] temp_hand = hand;
                temp_hand[0].Colour = "Red";
                temp_hand[0].Number = i;
                Piece temp_best_okey = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                temp_hand = Arrange(temp_hand);
                if (max_sum < get_Sum(temp_hand))
                {
                    max_sum = get_Sum(temp_hand);
                    best_okey.Colour = temp_best_okey.Colour;
                    best_okey.Number = temp_best_okey.Number;
                }
            }

            //trying black
            for (int i = 1; i < 14; i++)
            {
                Piece[] temp_hand = hand;
                temp_hand[0].Colour = "Black";
                temp_hand[0].Number = i;
                Piece temp_best_okey = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                temp_hand = Arrange(temp_hand);
                if (max_sum < get_Sum(temp_hand))
                {
                    max_sum = get_Sum(temp_hand);
                    best_okey.Colour = temp_best_okey.Colour;
                    best_okey.Number = temp_best_okey.Number;
                }
            }

            //trying yellow
            for (int i = 1; i < 14; i++)
            {
                Piece[] temp_hand = hand;
                temp_hand[0].Colour = "Yellow";
                temp_hand[0].Number = i;
                Piece temp_best_okey = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                temp_hand = Arrange(temp_hand);
                if (max_sum < get_Sum(temp_hand))
                {
                    max_sum = get_Sum(temp_hand);
                    best_okey.Colour = temp_best_okey.Colour;
                    best_okey.Number = temp_best_okey.Number;
                }
            }

            Console.WriteLine("\n\nOKEY placed as: " + best_okey.Colour + " " + best_okey.Number);

            hand[0].Colour = best_okey.Colour;
            hand[0].Number = best_okey.Number;
            hand = hand.OrderBy(c => c.Number).ToArray();
            organized_hand = Arrange(hand);
        }

        else
        {
            int max_sum = 0;
            Piece best_okey_1 = new Piece("", 0, 0, 0);
            Piece best_okey_2 = new Piece("", 0, 0, 0);

            //trying blue
            for (int i = 1; i < 14; i++)
            {
                //trying blue
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Blue";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Blue";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying red
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Blue";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Red";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying black
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Blue";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Black";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying yellow
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Blue";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Yellow";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }
            }

            //trying red
            for (int i = 1; i < 14; i++)
            {
                //trying blue
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Red";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Blue";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying red
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Red";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Red";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying black
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Red";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Black";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying yellow
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Red";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Yellow";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }
            }

            //trying black
            for (int i = 1; i < 14; i++)
            {
                //trying blue
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Black";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Blue";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying red
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Black";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Red";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying black
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Black";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Black";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying yellow
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Black";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Yellow";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }
            }

            //trying yellow
            for (int i = 1; i < 14; i++)
            {
                //trying blue
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Yellow";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Blue";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying red
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Yellow";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Red";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying black
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Yellow";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Black";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }

                //trying yellow
                for (int j = 1; j < 14; j++)
                {
                    Piece[] temp_hand = hand;
                    temp_hand[0].Colour = "Yellow";
                    temp_hand[0].Number = i;
                    temp_hand[1].Colour = "Yellow";
                    temp_hand[1].Number = j;
                    Piece temp_best_okey_1 = new Piece(temp_hand[0].Colour, temp_hand[0].Number, 0, 0);
                    Piece temp_best_okey_2 = new Piece(temp_hand[1].Colour, temp_hand[1].Number, 0, 0);
                    temp_hand = temp_hand.OrderBy(c => c.Number).ToArray();
                    temp_hand = Arrange(temp_hand);
                    if (max_sum < get_Sum(temp_hand))
                    {
                        max_sum = get_Sum(temp_hand);
                        best_okey_1.Colour = temp_best_okey_1.Colour;
                        best_okey_1.Number = temp_best_okey_1.Number;
                        best_okey_2.Colour = temp_best_okey_2.Colour;
                        best_okey_2.Number = temp_best_okey_2.Number;
                    }
                }
            }

            Console.WriteLine("\n\nFirst OKEY placed as: " + best_okey_1.Colour + " " + best_okey_1.Number);
            Console.WriteLine("Second OKEY placed as: " + best_okey_2.Colour + " " + best_okey_2.Number);

            hand[0].Colour = best_okey_1.Colour;
            hand[0].Number = best_okey_1.Number;
            hand[1].Colour = best_okey_2.Colour;
            hand[1].Number = best_okey_2.Number;
            hand = hand.OrderBy(c => c.Number).ToArray();
            organized_hand = Arrange(hand);
        }

        Console.WriteLine("\n\nOrganized hand:");
        int sum = 0;
        for (int i = 0; i < 21; i++)
        {
            if (organized_hand[i] == null)
                break;
            else
            {
                Console.WriteLine(organized_hand[i].Colour + " " + organized_hand[i].Number);
                sum += organized_hand[i].Number;
            }
        }

        Console.WriteLine("\n\nSum: " + sum);

        Console.WriteLine("\n\nUnused Pieces: ");
        for (int i = 0; i < 21; i++)
            if (hand[i] != null)
                Console.WriteLine(hand[i].Colour + " " + hand[i].Number + " c:" + hand[i].colourwise_count + " n:" + hand[i].numberwise_count);
    }
    public static int get_Sum(Piece[] hand)
    {
        int sum = 0;

        for (int i = 0; i < 21; i++)
        {
            if (hand[i] == null)
                break;
            else
                sum += hand[i].Number;
        }

        return sum;
    }
    public static Piece[] Arrange(Piece[] hand)
    {
        for (int i = 0; i < 21; i++)
        {
            hand[i].numberwise_count = 0;
            hand[i].colourwise_count = 0;
        }

        Piece[] organized_hand = new Piece[21];

        for (int i = 20; i >= 0; i--)
        {
            string[] colourwise_colours = new string[3];

            for (int j = 20; j >= 0; j--)
            {
                if (i != j && hand[i].Colour.Equals(hand[j].Colour) && hand[i].Number - hand[i].numberwise_count - 1 == hand[j].Number)
                {
                    hand[i].numberwise_count++;
                }
                if (i != j && hand[i].Number == hand[j].Number && !hand[i].Colour.Equals(hand[j].Colour) && (!colourwise_colours.Contains(hand[j].Colour)))
                {
                    colourwise_colours[hand[i].colourwise_count] = hand[j].Colour;
                    hand[i].colourwise_count++;
                }
            }
        }

        int current_index = 0;

        for (int i = 20; i >= 0; i--)
        {
            if (hand[i] != null)
            {
                if (hand[i].colourwise_count < 2 && hand[i].numberwise_count > 1)
                {
                    int colourwises_in_numberwise = 0;

                    for (int j = hand[i].numberwise_count; j >= 0; j--)
                        for (int k = 0; k < 21; k++)
                        {
                            if (hand[k] != null)
                                if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    if (hand[k].colourwise_count > 1)
                                        colourwises_in_numberwise++;
                        }

                    if (colourwises_in_numberwise < 2)
                        for (int j = hand[i].numberwise_count; j >= 0; j--)
                            for (int k = 0; k < 21; k++)
                            {
                                if (hand[k] != null)
                                    if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    {
                                        organized_hand[current_index] = hand[k];
                                        current_index++;
                                        hand[k] = null;
                                        break;
                                    }
                            }
                }
                else if (hand[i].colourwise_count > 1 && hand[i].numberwise_count < 2)
                {
                    Piece temp = hand[i];
                    string[] colourwise_colours = new string[4];
                    int colourwise_colours_index = 0;
                    int numberwises_in_colourwise = 0;

                    for (int k = temp.colourwise_count; k >= 0; k--)
                        for (int j = 0; j < 21; j++)
                            if (hand[j] != null)
                                if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                {
                                    if (hand[j].numberwise_count > 1)
                                        numberwises_in_colourwise++;

                                    colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                    colourwise_colours_index++;
                                }

                    for (int k = 0; k < 21; k++)
                        if (hand[k] != null)
                            if (hand[i].Colour.Equals(hand[k].Colour) && hand[k].Number == hand[i].Number - 1)
                                if (hand[k].colourwise_count > 1)
                                    numberwises_in_colourwise = 0;

                    colourwise_colours_index = 0;
                    colourwise_colours = new string[4];

                    if (numberwises_in_colourwise < 2)
                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                }
                else if (hand[i].colourwise_count > 2 && hand[i].numberwise_count < 2)
                {
                    Piece temp = hand[i];
                    string[] colourwise_colours = new string[4];
                    int colourwise_colours_index = 0;
                    int numberwises_in_colourwise = 0;

                    for (int k = temp.colourwise_count; k >= 0; k--)
                        for (int j = 0; j < 21; j++)
                            if (hand[j] != null)
                                if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                {
                                    if (hand[j].numberwise_count > 1)
                                        numberwises_in_colourwise++;

                                    colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                    colourwise_colours_index++;
                                }

                    colourwise_colours_index = 0;
                    colourwise_colours = new string[4];

                    if (numberwises_in_colourwise == 0)
                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                    else if (numberwises_in_colourwise == 1)
                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)) && hand[j].numberwise_count < 2)
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                }
                else if (hand[i].colourwise_count > 2 && hand[i].numberwise_count > 1)
                {
                    int colourwises_in_numberwise = 0;

                    for (int j = hand[i].numberwise_count; j >= 0; j--)
                        for (int k = 0; k < 21; k++)
                        {
                            if (hand[k] != null)
                                if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    if (hand[k].colourwise_count > 1)
                                        colourwises_in_numberwise++;
                        }

                    if (colourwises_in_numberwise > 2)
                    {
                        Piece temp = hand[i];
                        string[] colourwise_colours = new string[4];
                        int colourwise_colours_index = 0;

                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                    }
                    else
                        for (int j = hand[i].numberwise_count; j >= 0; j--)
                            for (int k = 0; k < 21; k++)
                            {
                                if (hand[k] != null)
                                    if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    {
                                        organized_hand[current_index] = hand[k];
                                        current_index++;
                                        hand[k] = null;
                                        break;
                                    }
                            }
                }
                else if (hand[i].colourwise_count == 2 && hand[i].numberwise_count > 2)
                {
                    Piece temp = hand[i];
                    string[] colourwise_colours = new string[4];
                    int colourwise_colours_index = 0;
                    int numberwises_in_colourwise = 0;

                    for (int k = temp.colourwise_count; k >= 0; k--)
                        for (int j = 0; j < 21; j++)
                            if (hand[j] != null)
                                if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                {
                                    if (hand[j].numberwise_count > 1)
                                        numberwises_in_colourwise++;

                                    colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                    colourwise_colours_index++;
                                }

                    colourwise_colours_index = 0;
                    colourwise_colours = new string[4];

                    if (numberwises_in_colourwise == 0)
                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                    else
                    {
                        for (int j = hand[i].numberwise_count; j >= 0; j--)
                            for (int k = 0; k < 21; k++)
                            {
                                if (hand[k] != null)
                                    if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    {
                                        organized_hand[current_index] = hand[k];
                                        current_index++;
                                        hand[k] = null;
                                        break;
                                    }
                            }
                    }
                }
                else if (hand[i].colourwise_count == 2 && hand[i].numberwise_count == 2)
                {
                    Piece temp = hand[i];
                    string[] colourwise_colours = new string[4];
                    int colourwise_colours_index = 0;
                    int numberwises_in_colourwise = 0;

                    for (int k = temp.colourwise_count; k >= 0; k--)
                        for (int j = 0; j < 21; j++)
                            if (hand[j] != null)
                                if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                {
                                    if (hand[j].numberwise_count > 1)
                                        numberwises_in_colourwise++;

                                    colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                    colourwise_colours_index++;
                                }

                    colourwise_colours_index = 0;
                    colourwise_colours = new string[4];

                    if (numberwises_in_colourwise < 2)
                        for (int k = temp.colourwise_count; k >= 0; k--)
                            for (int j = 0; j < 21; j++)
                            {
                                if (hand[j] != null)
                                    if (temp.Number == hand[j].Number && (!colourwise_colours.Contains(hand[j].Colour)))
                                    {
                                        colourwise_colours[colourwise_colours_index] = hand[j].Colour;
                                        colourwise_colours_index++;
                                        organized_hand[current_index] = hand[j];
                                        current_index++;
                                        hand[j] = null;
                                    }
                            }
                    else
                    {
                        for (int j = hand[i].numberwise_count; j >= 0; j--)
                            for (int k = 0; k < 21; k++)
                            {
                                if (hand[k] != null)
                                    if (hand[i].Colour.Equals(hand[k].Colour) && hand[i].Number - j == hand[k].Number)
                                    {
                                        organized_hand[current_index] = hand[k];
                                        current_index++;
                                        hand[k] = null;
                                        break;
                                    }
                            }
                    }
                }
                for (int x = 20; x >= 0; x--)
                {
                    if (hand[x] != null)
                    {
                        hand[x].numberwise_count = 0;
                        hand[x].colourwise_count = 0;
                        string[] temp_colourwise_colours = new string[3];

                        for (int j = 20; j >= 0; j--)
                            if (hand[j] != null)
                            {
                                if (x != j && hand[x].Number == hand[j].Number && !hand[x].Colour.Equals(hand[j].Colour) && (!temp_colourwise_colours.Contains(hand[j].Colour)))
                                {
                                    temp_colourwise_colours[hand[x].colourwise_count] = hand[j].Colour;
                                    hand[x].colourwise_count++;
                                }
                                if (x != j && hand[x].Colour.Equals(hand[j].Colour) && hand[x].Number - hand[x].numberwise_count - 1 == hand[j].Number)
                                {
                                    hand[x].numberwise_count++;
                                }
                            }
                    }
                }
            }
        }
        return organized_hand;
    }
}
