use crate::helpers::convert::*;

#[test]
fn verify(){
    use crate::helpers::files::*;
    assert_eq!( part_1( get_input("src/input/two_test.txt") ), 150);
    assert_eq!( part_2( get_input("src/input/two_test.txt") ), 900)
}

pub fn part_1(input: Vec<String>) -> i32{
    let (mut horizontal, mut depth) = (0,0);
    for line in input{
        let parts: Vec<&str> = line.split(" ").collect();
        let (direction, value) = (parts[0], to_i32(parts[1]));

        horizontal  += if direction == "forward"    { value } else {0};
        depth       += if direction == "down"       { value } else {0};
        depth       -= if direction == "up"         { value } else {0};
    }
    horizontal * depth
}

pub fn part_2(input: Vec<String>) -> i32{
    let mut horizontal = 0;
    let mut depth = 0;
    let mut aim = 0;
    for line in input{
        let parts: Vec<&str> = line.split(" ").collect();
        let direction = parts[0];
        let value = to_i32(parts[1]);

        match direction {
            "up" => aim = aim - value,
            "down" => aim = aim + value,
            "forward" => {
                horizontal = horizontal + value;
                depth = depth + value * aim;
            },
            _  => (),
        };
    }
    horizontal * depth
}