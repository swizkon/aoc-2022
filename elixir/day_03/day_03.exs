


defmodule Day3 do

    def solve_it(bags) do
        String.split(bags, ~r{(\r\n|\r|\n)})
            |> Enum.map(&(find_misplaced_item(&1)))
            |> Enum.map(&(calculate_priority(&1)))
            |> Enum.sum
    end

    defp find_misplaced_item(input) do
        middle = trunc(String.length(input)/2)

        compartments = input
            |> String.codepoints
            |> Enum.chunk_every(middle)
            |> Enum.map(&(Enum.uniq(&1)))

        [first_compartment, second_compartment] = compartments
        
        a_set = first_compartment
            |> Enum.into(MapSet.new)

        Enum.find(second_compartment, fn user_lang ->
            MapSet.member? a_set, user_lang
        end)
    end

    defp calculate_priority(<<char_code::utf8, _rest::binary>>) do
        case char_code do
             char_code when char_code >= 97 -> char_code - 96
            _ -> char_code - 38
        end
    end

end

 File.read!("day_03.txt")
    |> Day3.solve_it
    |> IO.puts

    
# the_input = File.read!("day_03.txt")
# result = Day3.solve_it the_input

# (the_input)

# IO.inspect bags

# bags = "vJrwpWtwJgWrhcsFMMfFFhFp
# jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
# PmmdzqPrVvPwwTWBwg
# wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
# ttgJtRGJQctTZtZT
# CrZsJsPPZsGzwwsLwLmpwMDw"

# bags_list = String.split(bags, ~r{(\r\n|\r|\n)})



# JUNK ---------------------------------------------------------------------------------------------------


# bags = File.read!("day_03.txt")

# IO.inspect bags

# # bags = "vJrwpWtwJgWrhcsFMMfFFhFp
# # jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
# # PmmdzqPrVvPwwTWBwg
# # wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
# # ttgJtRGJQctTZtZT
# # CrZsJsPPZsGzwwsLwLmpwMDw"

# bags_list = String.split(bags, ~r{(\r\n|\r|\n)})

# result = Day3.solve_it bags_list

# #  bags_list
# #     |> Enum.map(&(Day3.find_misplaced_item(&1)))
# #     |> Enum.map(&(Day3.calculate_priority(&1)))
# #     |> Enum.sum

# IO.puts result
