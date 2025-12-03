import { useEffect, useState } from "react";

const Day3 = () => {
    const [input, setInput] = useState([]);

    useEffect(() => {
        fetch('Inputs/day3.txt')
            .then(response => response.text())
            .then(data => {
                setInput(data.trim().split("\n").map(item => item.replace(/[^1-9]/g, "")));
            })
            .catch(error => console.error('Error fetching file:', error));
    }, []);

    const solvePart1 = () => {
        const joltages = [];

        input.forEach(batteries => {
            let highest = 0;

            for (let i = 0; i < batteries.length - 1; i++) {
                for (let j = i + 1; j < batteries.length; j++) {
                    const temp = batteries[i] + batteries[j];
                    if (temp > highest) {
                        highest = temp;
                    }
                }
            }

            joltages.push(highest);
        })

        const sum = joltages.map(Number).reduce((total, x) => total + x, 0);

        return sum;
    }

    const solvePart2 = () => {

        const joltages = [];

        input.forEach(batteries => {
            const batteriesArr = [...batteries];

            let needToRemove = batteriesArr.length - 12;
            while (needToRemove > 0) {
                for (let i = 0; i < batteriesArr.length - 1; i++) {
                    if (batteriesArr[i] < batteriesArr[i + 1]) {
                        batteriesArr.splice(i, 1);
                        break;
                    }
                }
                needToRemove--;
            }

            if (batteriesArr.length > 12) {
                batteriesArr.splice(12);
            }

            joltages.push(batteriesArr.join(''));
        })

        const sum = joltages.map(Number).reduce((total, x) => total + x, 0);

        return sum;
    }

    return (
        <div>
            <h2>Day 3: Lobby</h2>

            <p><span>Part 1:</span> {solvePart1()}</p>
            <p><span>Part 2:</span> {solvePart2()}</p>
        </div>
    )
}

export default Day3