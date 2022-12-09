


defmodule Day6 do

    def tuning_trouble(input) do
        # Pt 1
        tuning_trouble_chunks(input, 4)
        # Pt 2
        tuning_trouble_chunks(input, 14)
    end
    
    defp tuning_trouble_chunks(input, chunk) do

        all_uniq = &(Enum.count(&1) == Enum.count(Enum.uniq(&1)))

        data = input
            |> String.codepoints
            |> Enum.chunk_every(chunk,1)
            |> Enum.filter(all_uniq)
            |> hd
            |> Enum.join
        
        {a, b} = :binary.match input, data        
        a + b
    end

end


File.read!("day_06.txt")
    |> Day6.tuning_trouble
    |> IO.puts




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
