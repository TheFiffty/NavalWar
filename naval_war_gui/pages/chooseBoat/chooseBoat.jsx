/** @file chosseBoat.js
 * @brief       The page of add boats
 * @author      Ao XIE
 * @date        2023.02.02
 * @version     1.0.1
 * @copyright   Copyright (c) 2023 XIE Ao. All rights reserved.
 *****************************************************************
 * @attention
 * Development environment: macOS Ventura 13.2
 * @par Modification log:
 * <table>
 * <tr><th>Date        <th>Version  <th>Author    <th>Description
 * <tr><td>2023/02/03  <td>1.0      <td>Ao XIE  <td>Creating the initial version
 * </table>
 ******************************************************************
 */


import React from "react";
import { useState } from "react";
import { useRouter } from "next/router";
import styles from '../../styles/Home.module.css';

import BoatMap from "./boatMap";


export default function ChooseBoat() {
    const router = useRouter();
    // For the times of user.
    // 0 -> 4 user1
    // 5 -> 9 user2
    // 10 -> done
    const [user, setUser] = useState(0);
    const [boat, setBoat] = useState('');

    function splitDigits(num) {
        const tens = Math.floor(num / 10);
        const ones = num % 10;
        return [tens, ones];
    }

    function onSubmit(event) {
        /* let [x, y] = splitDigits(boat.location);
        console.log("tessst");
        event.preventDefault();
        fetch(`http://localhost:5199/api/Game/putBoat/${x}/${y}/${boat.direction}/${boat.size}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                if (!response.ok) {
                    return response.text().then((errorMessage) => {
                        throw new Error(errorMessage);
                    });
                }
            })
            .catch((error) => {
                alert(error.message);
            }); */
    }



    const getUser = () => {
        let userNow = "user1";
        if (4 < user && user <= 9) {
            userNow = "user2";
        }
        if (user == 10) {
            userNow = "Done";
            // After the two users finished their boat, 
            // turn to page of game.
            router.push('../battle/battleField');
        }
        return userNow;
    }

    const ShowUser = () => {
        let userNow = getUser();
        return (
            <h1 className="text-center">
                {userNow}
            </h1>
        );
    }

    var userNow = getUser();
    return (
        <div className={styles.mainmanu}>
            <ShowUser />
            <br />
            <BoatMap
                key={userNow}
                setBoat={onSubmit}
                user={user}
            />
        </div>
    )
}