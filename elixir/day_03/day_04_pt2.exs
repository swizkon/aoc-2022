
defmodule Day4Part2 do

    def solve_it(bags) do
        String.split(bags, ~r{(\r\n|\r|\n)})
            |> Enum.map(&(parse_values(&1)))
            |> Enum.sum
    end
    
    defp parse_values(input) do
        input
            |> String.split(",")
            |> Enum.map(&(String.split(&1, "-")))
            |> List.flatten
            |> Enum.map(&String.to_integer/1)
            |> find_overlaps
    end

    defp find_overlaps(input) do
        [a1, a2, b1, b2] = input

        case [a1, a2, b1, b2] do
             [a1, a2, b1, _] when a1 <= b1 and a2 >= b1 -> 1
             [a1, a2, b1, _] when a1 >= b1 and a2 <= b1 -> 1
             [a1, a2, _, b2] when a1 <= b2 and a2 >= b2 -> 1
             [a1, a2, _, b2] when a1 >= b2 and a2 <= b2 -> 1
             
             [a1, _, b1, b2] when b1 <= a1 and b2 >= a1 -> 1
             [a1, _, b1, b2] when b1 >= a1 and b2 <= a1 -> 1
             [_, a2, b1, b2] when b1 <= a2 and b2 >= a2 -> 1
             [_, a2, b1, b2] when b1 >= a2 and b2 <= a2 -> 1
            _ -> 0
        end
    end

end

#File.read!("day_04_test_input.txt")
File.read!("day_04.txt")
    |> Day4Part2.solve_it
    |> IO.puts


# Should be 70 with the test input....
