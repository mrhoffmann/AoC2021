//use crate::helpers::convert::*;

#[test]
fn verify(){
    use crate::helpers::files::*;
    assert_eq!( part_1( get_input("src/input/three_test.txt") ), 0);
    assert_eq!( part_2( get_input("src/input/three_test.txt") ), 0)
}

pub fn part_1(input: Vec<String>) -> i32{
    let (mut gamma, mut epsilon, mut i) = (0, 0, 0);
    
    while i < input.len()
    {
        let zeroes = numbers_at_position(input, i, '0');
        let ones = numbers_at_position(input, i, '1');
        println!("{} {}", zeroes, ones);
        i+=1;
    }
    return gamma * epsilon
}

fn numbers_at_position(haystack: Vec<String>, position: usize, needle: char) -> i32{
    let mut found = 0;
    for needles in haystack{ // each line
        if needles.chars().nth(position).unwrap() == needle { //line at position
            found+=1;
        }
    }
    found
}

pub fn part_2(input: Vec<String>) -> i32{
    0
}