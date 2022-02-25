//Iteration 9

Box a = new Box(9.0, 5.0, 5.0);
Console.WriteLine("Box A: " + a.ToString());

Console.WriteLine();

Box b = new Box(9.0, 4.0, 4.0);
Console.WriteLine("Box B: " + b.ToString());

Console.WriteLine();

Box c = a + b;
Console.WriteLine("Box C: " + c.ToString());

List<Box> boxes = new List<Box> { a, b, c };

boxes.Sort();
boxes.Reverse();

foreach (Box d in boxes)
{
    Console.WriteLine("Volume: " + d.Volume);
}