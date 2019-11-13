import {createAppContainer, createSwitchNavigator} from 'react-navigation';
import {createStackNavigator} from 'react-navigation-stack';
import {createBottomTabNavigator} from 'react-navigation-tabs';

import MainScreen from './pages/main';
import ProfileScreen from './pages/profile';
import SignInScreen from './pages/signin';


const AuthStack = createStackNavigator({
  Sign: {screen: SignInScreen},
});

const MainNavigator = createBottomTabNavigator(
  {
    Main: {
      screen: MainScreen,
    },
    Profile: {
      screen: ProfileScreen,
    },
  },
  {
    initialRouteName: 'Main',
    tabBarOptions: {
      showIcon: true,
      showLabel: false,
      inactiveBackgroundColor: '#191919',
      activeBackgroundColor: '#303030',
      style: {
        width: '100%',
        height: 50,
      },
    },
  },
);

export default createAppContainer(
  createSwitchNavigator(
    {
      MainNavigator,
      AuthStack,
    },
    {
      initialRouteName: 'AuthStack',
    },
  ),
);
