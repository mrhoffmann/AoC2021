use aoc_2021::helpers::files::*;
use aoc_2021::days::*;

fn main() {
    println!("{}", one::part_1(get_int_input("src/input/one_part_1.txt")));
    println!("{}", one::part_2(get_int_input("src/input/one_part_2.txt")));
    println!("{}", two::part_1(get_input("src/input/two_part_1.txt")));
    println!("{}", two::part_2(get_input("src/input/two_part_2.txt")));
    println!("{}", three::part_1(get_input("src/input/three_part_1.txt")));
    println!("{}", three::part_2(get_input("src/input/three_part_2.txt")));
}