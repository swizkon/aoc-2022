
defmodule Day3Part2 do

    def solve_it(bags) do
        String.split(bags, ~r{(\r\n|\r|\n)})
            |> Enum.chunk_every(3)
            |> Enum.map(&(find_common_item(&1)))
            |> Enum.map(&(calculate_priority(&1)))
            |> Enum.sum
    end
    
    defp find_common_item(input) do
        [a, b, c] = input
            |> Enum.map(&(String.codepoints(&1)))
            |> Enum.map(&(Enum.uniq(&1)))
            |> Enum.map(&(Enum.into(&1, MapSet.new)))

        a   |> MapSet.intersection(b)
            |> MapSet.intersection(c)
            |> MapSet.to_list
            |> List.first
    end

    defp calculate_priority(<<char_code::utf8, _rest::binary>>) do
        case char_code do
             char_code when char_code >= 97 -> char_code - 96
            _ -> char_code - 38
        end
    end

end

 # File.read!("day_03_test_input.txt")
 File.read!("day_03.txt")
    |> Day3Part2.solve_it
    |> IO.puts


# Should be 70 with the test input....
