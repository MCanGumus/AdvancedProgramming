int[] d1 = (int[])Array.CreateInstance(typeof(int), 2);
int[,,] d2 = (int[,,])Array.CreateInstance(typeof(int), 2, 3, 4);

(int a, string b)[] array = new (int a, string b)[]
{
    (0, "x"),
    (1, "y"),
    (2, "z"),
    (3, "t"),
    (4, "v"),
}; // Tuple

(int a, string b)[] arr =
[
    (0, "x"),
    (0, "y"),
    (0, "z"),
    (0, "t"),
    (0, "v"),
]; // Tuple