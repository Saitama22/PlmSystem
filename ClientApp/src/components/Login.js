import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login;

  constructor(props) {
    super(props);
  }



  render() {
    return (
        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <div>
                <div>Логин или Email</div>
                <input type="text"></input>
                <p></p>
                <div>Пароль</div>
                <input type="text"></input>
                <p></p>
                <div style={{ display: 'flex', flexdirection: 'row', justifyContent: 'space-between' }}>
                    <button type="button" class="btn btn-primary">Отправить</button>
                    <button type="button" class="btn btn-light">Отмена</button>
                </div>
            </div>
      </div>
    );
  }
}
