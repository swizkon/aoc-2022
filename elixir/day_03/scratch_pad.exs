


defmodule Day3 do
    
    def calc(input) do
        # i input
        IO.puts input

        middle = trunc(String.length(input)/2)

        IO.puts middle

        compartments = input
            |> String.codepoints
            |> Enum.chunk_every(middle)
            #|> 
            # |> Enum.uniq()
            #|> Enum.map(&Enum.join/1)

        # input
        #     |> String.codepoints
        #     |> Enum.chunk_every(middle)
        #     |> Enum.uniq()
        #     |> Enum.map(&Enum.join/1)

        # IO.puts 

        #a = mix |> Enum.slice(0..0)
        #b = mix |> Enum.slice(1..1)

        [first_compartment, second_compartment] = compartments

        IO.puts first_compartment |> Enum.uniq()
        IO.puts second_compartment |> Enum.uniq()

        # IO.puts a1 # |> String.split # |> MapSet.new |> Enum.to_list # |> String.codepoints
        # IO.puts b # |> String.codepoints

        a_set = first_compartment |> Enum.uniq() |> Enum.into(MapSet.new)

        overlap = Enum.find(second_compartment, fn user_lang ->
            MapSet.member? a_set, user_lang
        end)

        IO.puts input <> " is overlapping"
        IO.puts overlap
        # IO.puts b
    end

end

#res = Day3.calc("vJrwpWtwJgWrhcsFMMfFFhFp")


res = Day3.calc("PmmdzqPrVvPwwTWBwg")

#res = Day3.calc("vJrwpWtwJgWrhcsFMMfFFhFp")

IO.puts res

supported_langs = ["a", "b", "c"]
user_langs = ["z", "s", "b", "a"]

supported_langs_set = supported_langs |> Enum.into(MapSet.new)

dd = Enum.find(user_langs, fn user_lang ->
  MapSet.member? supported_langs_set, user_lang
end)



IO.puts dd