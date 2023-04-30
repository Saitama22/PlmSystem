
import { useState, useEffect } from 'react';

function TempQ() {
    const [forecasts, setPosts] = useState([]);
    useEffect(() => {
        fetch('api/wet/get-weather/test')
            .then((res) => res.json())
            .then((data) => {
                console.log(data);
                setPosts(data);
            });
    }, []);


    return (
        <div>
            <h1>Практическая часть работы</h1>
            <p></p>
            <div style={{ display: 'flex', flexdirection: 'row', justifyContent: 'space-between' }}>
                <span style={{ width: '900px' }}>Описание задачи: написать практическую часть работы</span>
                <div>
                    <div>
                        <b>Этап</b>
                        <div>В работе</div>
                    </div>
                    <div>
                        <b>Исполнители</b>
                        <div>Ежиков С. А.</div>
                    </div>
                    <div>
                        <b>Дата старта</b>
                        <div>12:12 12.12.2001</div>
                    </div>
                    <div>
                        <b>Дата окончания</b>
                        <div>12:12 17.12.2001</div>
                    </div>
                    <div>
                        <b>Осталость</b>
                        <div>5 дней</div>
                    </div>
                </div>
            </div>
            <h5>Комментарии</h5>
            <div >
                <textarea placeholder="Пишите здесь" width="500px"></textarea>
                <div></div>
                <button type="button" class="btn btn-primary">Отправить</button>
                <hr></hr>
                <p></p>
                <div>
                    <b>Тестов Т. Т.</b>
                    <div></div>
                    <span>Комментарий 1</span>
                </div>
                <hr></hr>
                <p></p>
                <div >
                    <b>Администратор А. А.</b>
                    <div></div>
                    <span>Комментарий 2</span>
                </div>
            </div>
        </div>
    );
}

export default TempQ;