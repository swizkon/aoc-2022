
defmodule Day4Part1 do

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
            |> find_common_item
    end

    defp find_common_item(input) do
        [a1, a2, b1, b2] = input

        case [a1, a2, b1, b2] do
             [a1, a2, b1, b2] when a1 <= b1 and a2 >= b2 -> 1
             [a1, a2, b1, b2] when a1 >= b1 and a2 <= b2 -> 1
            _ -> 0
        end
    end

end

# File.read!("day_04_test_input.txt")
File.read!("day_04.txt")
    |> Day4Part1.solve_it
    |> IO.puts


# Should be 70 with the test input....
