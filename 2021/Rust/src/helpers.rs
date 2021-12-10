pub mod files{
    use std::{
        fs::File,
        io::{prelude::*, BufReader},
        path::Path,
    };

    pub fn get_input(filename: impl AsRef<Path>) -> Vec<String> {
        let file = File::open(filename).expect("no such file");
        let buf = BufReader::new(file);
        buf.lines()
            .map(|l| l.expect("Could not parse line"))
            .collect()
    }
    
    pub fn get_int_input(filename: impl AsRef<Path>) -> Vec<i64> {
        get_input(filename).iter().map(|x| x.parse::<i64>().unwrap()).collect()
    }
}

pub mod convert{
    pub fn to_i32(s: &str) -> i32{
        s.parse::<i32>().unwrap()
    }
}