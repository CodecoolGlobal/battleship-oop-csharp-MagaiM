namespace Codecool.Battleship.Enums
{
    enum SquareStatus
    {
        Empty = '~',
        Ship = 'X',
        Hit = '#',
        Missed = '@',
        Sunk = 'S',
        NexToSunk = '≈' //place holder char.
    }
}