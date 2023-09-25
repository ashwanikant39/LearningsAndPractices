import java.awt.*;
import java.awt.event.*;

public class CalculatorAWT extends Frame implements ActionListener {
    private TextField textField;
    private String currentInput = "";

    public CalculatorAWT() {
        setTitle("Calculator");
        setSize(400, 400);
        setLayout(new BorderLayout());

        // Panel for the name and roll number
        Panel namePanel = new Panel(new BorderLayout());
        TextField nameTextField = new TextField("Roll Number: 2104942                                              NAME : bhushan Sharma");
        nameTextField.setEditable(false);
        namePanel.add(nameTextField, BorderLayout.NORTH);
        add(namePanel, BorderLayout.NORTH);

        // Panel for the calculation text field and buttons
        Panel calculationPanel = new Panel(new BorderLayout());

        textField = new TextField();
        textField.setEditable(false);
        calculationPanel.add(textField, BorderLayout.NORTH);

        Panel buttonPanel = new Panel(new GridLayout(4, 4));
        String[] buttonLabels = {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "C", "0", "=", "+"
        };

        for (String label : buttonLabels) {
            Button button = new Button(label);
            button.addActionListener(this);
            buttonPanel.add(button);
        }

        calculationPanel.add(buttonPanel, BorderLayout.CENTER);
        add(calculationPanel, BorderLayout.CENTER);

        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent windowEvent) {
                System.exit(0);
            }
        });

        setVisible(true);
    }

   
   public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();

        if (command.equals("=")) {
            try {
                // Evaluate the expression and display the result
                currentInput = String.valueOf(evalExpression(currentInput));
            } catch (Exception ex) {
                currentInput = "Error";
            }
        } else if (command.equals("C")) {
            // Clear the input
            currentInput = "";
        } else {
            // Append the clicked button label to the input
            currentInput += command;
        }

        textField.setText(currentInput);
    }

    private double evalExpression(String expression) {
        return new Object() {
            int pos = -1, ch;

            void nextChar() {
                ch = (++pos < expression.length()) ? expression.charAt(pos) : -1;
            }

            boolean eat(int charToEat) {
                while (ch == ' ') nextChar();
                if (ch == charToEat) {
                    nextChar();
                    return true;
                }
                return false;
            }

            double parse() {
                nextChar();
                double x = parseExpression();
                if (pos < expression.length()) throw new RuntimeException("Unexpected: " + (char) ch);
                return x;
            }

            double parseExpression() {
                double x = parseTerm();
                for (;;) {
                    if (eat('+')) x += parseTerm();
                    else if (eat('-')) x -= parseTerm();
                    else return x;
                }
            }

            double parseTerm() {
                double x = parseFactor();
                for (;;) {
                    if (eat('*')) x *= parseFactor();
                    else if (eat('/')) x /= parseFactor();
                    else return x;
                }
            }

            double parseFactor() {
                if (eat('+')) return parseFactor();
                if (eat('-')) return -parseFactor();

                double x;
                int startPos = this.pos;
                if (eat('(')) {
                    x = parseExpression();
                    eat(')');
                } else if ((ch >= '0' && ch <= '9') || ch == '.') {
                    while ((ch >= '0' && ch <= '9') || ch == '.') nextChar();
                    x = Double.parseDouble(expression.substring(startPos, this.pos));
                } else {
                    throw new RuntimeException("Unexpected: " + (char) ch);
                }

                return x;
            }
        }.parse();
    }

    public static void main(String[] args) {
        new CalculatorAWT();
    }
}