


defmodule Day3 do
    
    def calc(input) do
        # i input
        IO.puts input

        middle = trunc(String.length(input)/2)

        IO.puts middle

        compartments = input
            |> String.codepoints
            |> Enum.chunk_every(middle)
        # IO.puts 

        #a = mix |> Enum.slice(0..0)
        #b = mix |> Enum.slice(1..1)

        [first_compartment, second_compartment] = compartments

        IO.puts first_compartment |> Enum.uniq()
        IO.puts second_compartment |> Enum.uniq()

        # IO.puts a1 # |> String.split # |> MapSet.new |> Enum.to_list # |> String.codepoints
        # IO.puts b # |> String.codepoints

        a_set = first_compartment
            # |> Enum.uniq()
            |> Enum.into(MapSet.new)

        overlap = Enum.find(second_compartment, fn user_lang ->
            MapSet.member? a_set, user_lang
        end)

        IO.puts input <> " has overlapping " <> overlap
        # IO.puts overlap
        # IO.puts b
    end


    def find_misplaced_item(input) do
        middle = trunc(String.length(input)/2)

        compartments = input
            |> String.codepoints
            |> Enum.chunk_every(middle)

        [first_compartment, second_compartment] = compartments

        #IO.puts first_compartment |> Enum.uniq()
        #IO.puts second_compartment |> Enum.uniq()

        a_set = first_compartment
            |> Enum.uniq()
            |> Enum.into(MapSet.new)

        overlap = Enum.find(second_compartment, fn user_lang ->
            MapSet.member? a_set, user_lang
        end)

        IO.puts input <> " has find_misplaced_item " <> overlap
        overlap
    end


    def calculate_priority(<<char_code::utf8, _rest::binary>>) do
        # IO.inspect char_code

        case char_code do
             char_code when char_code >= 97 ->
                char_code - 96
            _ -> char_code - 38
        end
    end

    #def char?(<<c::utf8>>), do: true
    #def char?(<<f::utf8, _rest::binary>>), do: char?(f)


    # def char?(inp) do
    #     <<v::utf8>> = inp
    #     char? v
    # end
    
    def calculate_priority(inp), do: false

end


bags = "vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw"

bags_list = String.split(bags, ~r{(\r\n|\r|\n)})

# IO.puts bags_list


bags_list
    # |> Enum.to_list
    |> Enum.map(&(Day3.find_misplaced_item(&1)))
    |> Enum.map(&(Day3.calculate_priority(&1)))

    # |> Day3.find_misplaced_item

# res = Day3.find_misplaced_item("vJrwpWtwJgWrhcsFMMfFFhFp")

# IO.puts res




IO.puts "------------------------------"

IO.puts Day3.calculate_priority("p")

IO.puts "------------------------------"
IO.puts Day3.calculate_priority("L")

IO.puts "------------------------------"
IO.puts Day3.calculate_priority("P")

IO.puts "------------------------------"
IO.puts Day3.calculate_priority("v")

IO.puts "------------------------------"
IO.puts Day3.calculate_priority("t")



# supported_langs = ["a", "b", "c"]
# user_langs = ["z", "s", "b", "a"]

# supported_langs_set = supported_langs |> Enum.into(MapSet.new)

# dd = Enum.find(user_langs, fn user_lang ->
#   MapSet.member? supported_langs_set, user_lang
# end)

# IO.puts dd