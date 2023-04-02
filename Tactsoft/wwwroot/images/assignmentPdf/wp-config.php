<?php
/**
 * The base configuration for WordPress
 *
 * The wp-config.php creation script uses this file during the installation.
 * You don't have to use the web site, you can copy this file to "wp-config.php"
 * and fill in the values.
 *
 * This file contains the following configurations:
 *
 * * Database settings
 * * Secret keys
 * * Database table prefix
 * * ABSPATH
 *
 * @link https://wordpress.org/support/article/editing-wp-config-php/
 *
 * @package WordPress
 */

// ** Database settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define( 'DB_NAME', 'techgxtq_wp799' );

/** Database username */
define( 'DB_USER', 'techgxtq_wp799' );

/** Database password */
define( 'DB_PASSWORD', '2oyp3J]p.s][Sq@7' );

/** Database hostname */
define( 'DB_HOST', 'localhost' );

/** Database charset to use in creating database tables. */
define( 'DB_CHARSET', 'utf8' );

/** The database collate type. Don't change this if in doubt. */
define( 'DB_COLLATE', '' );

/**#@+
 * Authentication unique keys and salts.
 *
 * Change these to different unique phrases! You can generate these using
 * the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}.
 *
 * You can change these at any point in time to invalidate all existing cookies.
 * This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define( 'AUTH_KEY',         'ukto74k2cpxqqoozvpotdqsvexdinndav27vbyapjeeflbms2um8quun2l9fmwrb' );
define( 'SECURE_AUTH_KEY',  'xxiezpfdpm5fma1gcz1dpyjpdofc8kevraeqc5zmcauizhrcwjnqsmcp1ldp9dh0' );
define( 'LOGGED_IN_KEY',    'btkta9axcnolebnpbp0dz4r8aqafwionvtqiuozcgwryxkpsct6gf9fttfyyqrdh' );
define( 'NONCE_KEY',        'rtsn6v89jk1wbqekerqzg5y3rxrq1r8kej7h28eiepu7m89mr5gcebpgvq9a5crn' );
define( 'AUTH_SALT',        '3wbhtm335h18asobxpk4syl8pjmkh5gbne89yttqar1us1h3nb8vg3ihi53z9inm' );
define( 'SECURE_AUTH_SALT', 'h5hfplzxbqmpjriw0mrmoforkmubjr4ukuv4mwelnmmoekomoz6m51auiupk3qxc' );
define( 'LOGGED_IN_SALT',   's4ttggggfcb4u7pltb2274zgwj7i9li015w19ff2c36dh1hid59fg93uhutnwyu5' );
define( 'NONCE_SALT',       'npoabx3lb8umafhvyudlcxhl8jivabubnfvk5dinv9rvdygz6vl7ilbjrlstilwk' );

/**#@-*/

/**
 * WordPress database table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix = 'wprh_';

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 *
 * For information on other constants that can be used for debugging,
 * visit the documentation.
 *
 * @link https://wordpress.org/support/article/debugging-in-wordpress/
 */
define( 'WP_DEBUG', false );

/* Add any custom values between this line and the "stop editing" line. */



/* That's all, stop editing! Happy publishing. */

/** Absolute path to the WordPress directory. */
if ( ! defined( 'ABSPATH' ) ) {
	define( 'ABSPATH', __DIR__ . '/' );
}

/** Sets up WordPress vars and included files. */
require_once ABSPATH . 'wp-settings.php';
