#[test]
fn verify(){
    use crate::helpers::files::*;
    assert_eq!( part_1( get_int_input("src/input/one_test.txt") ), 7);
    assert_eq!( part_2( get_int_input("src/input/one_test.txt") ), 5)
}

pub fn part_1(input: Vec<i64>) -> i32 {
    let (mut retval, mut previous_value) = (0,0);    
    for line in input {
        retval += if previous_value > 0 { if previous_value < line { 1 } else { 0 } } else { 0 };
        previous_value = line;
    }
    retval
}

pub fn part_2(input: Vec<i64>) -> i32 {
    let (mut i, mut retval, mut previous) = (0, 0, 0);
    while i < input.len() - 3 {
        let _sum = input[i] + input[i+1] + input[i+2];        
        retval += if previous < _sum { 1 } else { 0 };
        previous = _sum;
        i += 1;
    }

    retval
}