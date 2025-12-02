import { useEffect, useState } from "react";

const Day1 = () => {

    const [input, setInput] = useState('');

    useEffect(() => {
        fetch('Inputs/day1.txt')
            .then(response => response.text())
            .then(data => {
                setInput(data.split("\n"));
            })
            .catch(error => console.error('Error fetching file:', error));
    }, []);

    const solvePart1 = () => {
        
        let position = 50;
        let numberOfZeros = 0;

        for (let i = 0; i < input.length; i++) {
            const item = input[i].split(/(?<=\D)(?=\d)|(?<=\d)(?=\D)/);
            const direction = item[0];
            const distance = Number(item[1]);

            switch (direction) {
                case "R":
                    position = (position + distance) % 100;
                    break;
                case "L":
                    position = (position - distance % 100 + 100) % 100;
                    break;
            }

            if (position == 0) {
                numberOfZeros++;
            }
        }

        return numberOfZeros;
    }

    const solvePart2 = () => {
        return "Solution"
    }

    return (
        <div>
            <h2>Day 1: Secret Entrance</h2>
            <p><span>Part 1:</span> {solvePart1()}</p>
            <p><span>Part 2:</span> {solvePart2()}</p>
        </div>
    )
}

export default Day1