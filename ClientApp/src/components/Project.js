import React from 'react';
import { useState } from "react";
import './NavMenu.css';
import Task from './Task';

function Project() {
    return (
        <div>
            <h2>Проект 1</h2>
            <span>Создание прототипа системы управления проектами</span>
            <p></p>
            <div style={{ display: 'flex', flexdirection: 'row', justifyContent: 'space-between', width:'800px' }}>
                <div style={{ display: 'inline-block'  }}>
                    <b>Надо сделать</b>
                    <p></p>
                    <Task></Task>                     
                    <p></p>
                    <Task></Task> 
                </div>
                <div class="vl" style={{ display: 'inline-block' }}></div>
                <div style={{ display: 'inline-block' }}>
                    <b>В работе</b>
                    <p></p>
                    <Task></Task>
                </div>
                <div class="vl" style={{ display: 'inline-block' }}></div>
                <div style={{ display: 'inline-block' }}>
                    <b>Сделано</b>
                    <p></p>
                    <Task></Task>
                </div>
            </div>
        </div>
    );
}

export default Project;