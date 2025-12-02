import { useEffect, useState } from "react";

const Day2 = () => {
    const [input, setInput] = useState('');

    useEffect(() => {
        fetch('Inputs/day2.txt')
            .then(response => response.text())
            .then(data => {
                setInput(data.split(","));
            })
            .catch(error => console.error('Error fetching file:', error));
    }, []);

    const allIds = [];

    const getAllIds = () => {
        for (let i = 0; i < input.length; i++) {
            const item = input[i];
            const idRange = item.split('-').map(Number);
            Array.from({ length: idRange[1] - idRange[0] + 1 }, (_, i) => idRange[0] + i)
                .forEach(id => allIds.push(id));
        }
    }

    const solvePart1 = () => {
        const invalidIds = [];

        getAllIds();

        allIds.forEach(id => {
            const idString = id.toString();
            const midpoint = Math.ceil(idString.length / 2);
            const firstHalf = idString.slice(0, midpoint);
            const secondHalf = idString.slice(midpoint);

            if (firstHalf == secondHalf) {
                invalidIds.push(id);
            }
        })

        const sum = invalidIds.reduce((total, x) => total + x, 0);

        return sum;
    }

    const solvePart2 = () => {
        const invalidIds = [];

        allIds.forEach(id => {
            const idString = id.toString();
            if ((idString.length % 2 == 0 && idString.match(/^0*(\d+)\1+$/g)) ||
                (idString.length % 2 != 0 && idString.match(/^([1-9]+)\1+$/))) {
                invalidIds.push(id);
            }
        })

        const sum = invalidIds.reduce((total, x) => total + x, 0);

        return sum;
    }

    return (
        <div>
            <h2>Day 2: Gift Shop</h2>

            <p><span>Part 1:</span> {solvePart1()}</p>
            <p><span>Part 2:</span> {solvePart2()}</p>
        </div>
    )
}

export default Day2